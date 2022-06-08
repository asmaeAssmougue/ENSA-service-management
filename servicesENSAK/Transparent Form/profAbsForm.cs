using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transparent_Form
{
    public partial class profAbsForm : Form
    {
        public profAbsForm()
        {
            InitializeComponent();
        }
        Absence absence = new Absence();
        private void showData()
        {
            //to show absence list on datagridview
            string cin = ClassSession.cinProf;
            dataGridViewAbs.DataSource = absence.GetAbsence(new MySqlCommand("SELECT id,cne_student,module,nb_absence FROM `abscence` where cin_prof = '" + cin +"'"));
        }
        private void button_Ajout_Click(object sender, EventArgs e)
        {
            if (textCNE.Text == "" || comboxMod.Text == "" || nbrAbs.Text == "")
            {
                MessageBox.Show("veuillez remplir tous les champs", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string CNE = textCNE.Text;
               
                string cin = ClassSession.cinProf; 
                int Abs = Convert.ToInt32(nbrAbs.Text);
                string Mod = comboxMod.Text;

                DBconnect connect = new DBconnect();
                connect.openConnect();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `etudiant` WHERE cne = '" + textCNE.Text + "'", connect.getconnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                int i = ds1.Tables[0].Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("le cne saisie ne corespond à aucun etudiant, réessayez", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                 
                  
                   

                      
                        MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM `abscence` WHERE cne_student = '" + textCNE.Text + "' and cin_prof = '" + cin + "' and module = '" + comboxMod.Text + "'", connect.getconnection);
                        MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                        DataSet ds13 = new DataSet();
                        da3.Fill(ds13);
                        int k = ds13.Tables[0].Rows.Count;
                        if (k == 0)
                        {
                            connect.closeConnect();
                            if (absence.insertAbsence(CNE, cin, Mod, Abs))
                            {
                                showData();
                                button_clear.PerformClick();
                                MessageBox.Show("l'absence est ajouté ", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {

                                MessageBox.Show("une erreur est produite, réessayez", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else

                        {
                            connect.openConnect();
                            MySqlCommand command = new MySqlCommand("UPDATE `abscence` SET `nb_absence`= '" + nbrAbs.Text + "' WHERE cne_student = '" + textCNE.Text + "' and cin_prof = '" + cin + "' and module = '" + comboxMod.Text + "' ", connect.getconnection);
                          

                            //message de confirmation
                            if (command.ExecuteNonQuery() == 1)
                            {
                                showData();
                                MessageBox.Show("l'absence est modifié ", "modifie absence", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // return true;
                                connect.closeConnect();
                            }
                            else
                            {
                                MessageBox.Show("une erreur est produite, réessayez", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connect.closeConnect();
                                // return false;
                            }

                      




                        


                    }
                }


            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (textCNE.Text == "" ||  nbrAbs.Text == "")
            {
                MessageBox.Show("veuillez remplir tous les champs", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string CNE = textCNE.Text;
                string cin = ClassSession.cinProf;

                int Abs = Convert.ToInt32(nbrAbs.Text);
                string Mod = comboxMod.Text;

                DBconnect connect = new DBconnect();
                connect.openConnect();
                MySqlCommand command = new MySqlCommand("UPDATE `abscence` SET `nb_absence`= '" + nbrAbs.Text + "' WHERE cne_student = '" + textCNE.Text + "' and cin_prof = '" + cin + "' and module = '" + comboxMod.Text + "' ", connect.getconnection);
            

                if (command.ExecuteNonQuery() == 1)
                {
                    showData();
                    MessageBox.Show("l'absence est modifié ", "modifie absence", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // return true;
                    connect.closeConnect();
                }
                else
                {
                    MessageBox.Show("une erreur est produite, réessayez", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connect.closeConnect();
                    // return false;
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textCNE.Clear();

           
            nbrAbs.Clear();
        }

        private void profAbsForm_Load(object sender, EventArgs e)
        {
            showData();
            string cin = ClassSession.cinProf;
            comboxMod.DataSource = absence.getModule(new MySqlCommand("SELECT * FROM `module` where cin_prof = '"+ cin +"'"));
            comboxMod.DisplayMember = "nom";
            comboxMod.ValueMember = "nom";
        }

        private void selectrowclick(object sender, EventArgs e)
        {
            textCNE.Text = dataGridViewAbs.CurrentRow.Cells[1].Value.ToString();
           
            comboxMod.Text = dataGridViewAbs.CurrentRow.Cells[2].Value.ToString();
            nbrAbs.Text = dataGridViewAbs.CurrentRow.Cells[3].Value.ToString();
        }

        private void back(object sender, EventArgs e)
        {
            FormProf clt = new FormProf();
            clt.Show();
        }
    }
}
