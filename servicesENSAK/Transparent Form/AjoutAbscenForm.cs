using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Transparent_Form
{
    public partial class AjoutAbscenForm : Form

    {
        Absence absence = new Absence();
        public AjoutAbscenForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
   
        private void button_Update_Click(object sender, EventArgs e)
        {

        }
         private void CourseForm_Load(object sender, EventArgs e)
         {
             showData();
         }
       private void showData()
        {
            //to show absence list on datagridview
            dataGridViewAbs.DataSource = absence.GetAbsence(new MySqlCommand("SELECT * FROM `abscence`"));
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
             textCNE.Clear();

            textCIN.Clear();
            nbrAbs.Clear();
           

        }

        private void nbrAbs_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Ajout_Click(object sender, EventArgs e)
        {
            if (textCNE.Text == "" || textCIN.Text == "" || nbrAbs.Text == "")
            {
                MessageBox.Show("veuillez remplir tous les champs", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string CNE = textCNE.Text;

                string CIN = textCIN.Text;
                int Abs = Convert.ToInt32(nbrAbs.Text);
                string Mod = comboxMod.Text;

                DBconnect connect = new DBconnect();
                connect.openConnect();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `etudiant` WHERE cne = '"+ textCNE.Text + "'", connect.getconnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                int i = ds1.Tables[0].Rows.Count;
                if (i==0)
                {
                    MessageBox.Show("le cne saisie ne corespond à aucun etudiant, réessayez", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM `professeur` WHERE cin = '" + textCIN.Text + "'", connect.getconnection);
                    MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                    DataSet ds12 = new DataSet();
                    da2.Fill(ds12);
                    int j = ds12.Tables[0].Rows.Count;
                    if(j==0)
                    {
                        MessageBox.Show("le cin saisie ne corespond à aucun prof, réessayez", "Ajouter absence", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        //connect.closeConnect();
                        MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM `abscence` WHERE cne_student = '" + textCNE.Text + "' and cin_prof = '"+ textCIN.Text + "' and module = '"+ comboxMod.Text + "'", connect.getconnection);
                        MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                        DataSet ds13 = new DataSet();
                        da3.Fill(ds13);
                        int k = ds13.Tables[0].Rows.Count;
                        if (k == 0)
                        {
                            connect.closeConnect();
                            if (absence.insertAbsence(CNE, CIN, Mod, Abs))
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
                            MySqlCommand command = new MySqlCommand("UPDATE `abscence` SET `nb_absence`= '"+ nbrAbs.Text + "' WHERE cne_student = '" + textCNE.Text + "' and cin_prof = '" + textCIN.Text + "' and module = '" + comboxMod.Text + "' ", connect.getconnection);
                          //  command.ExecuteNonQuery();
                          //  connect.closeConnect();
                          
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
        }

        private void selectRowClick(object sender, EventArgs e)
        {
            textCNE.Text = dataGridViewAbs.CurrentRow.Cells[1].Value.ToString();
            textCIN.Text = dataGridViewAbs.CurrentRow.Cells[2].Value.ToString();
            comboxMod.Text = dataGridViewAbs.CurrentRow.Cells[3].Value.ToString();
            nbrAbs.Text = dataGridViewAbs.CurrentRow.Cells[4].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAbs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AjoutAbscenForm_Load_1(object sender, EventArgs e)
        {
            showData();
            comboxMod.DataSource = absence.getModule(new MySqlCommand("SELECT * FROM `module`"));
            comboxMod.DisplayMember = "nom";
            comboxMod.ValueMember = "nom";
        }

        private void UpdateClick(object sender, EventArgs e)
        {

            if (textCNE.Text == "" || textCIN.Text == "" || nbrAbs.Text == "")
            {
                MessageBox.Show("veuillez remplir tous les champs", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string CNE = textCNE.Text;

                string CIN = textCIN.Text;
                int Abs = Convert.ToInt32(nbrAbs.Text);
                string Mod = comboxMod.Text;

                DBconnect connect = new DBconnect();
                connect.openConnect();
                MySqlCommand command = new MySqlCommand("UPDATE `abscence` SET `nb_absence`= '" + nbrAbs.Text + "' WHERE cne_student = '" + textCNE.Text + "' and cin_prof = '" + textCIN.Text + "' and module = '" + comboxMod.Text + "' ", connect.getconnection);
               // command.ExecuteNonQuery();
               // connect.closeConnect();
                
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

        private void comboxMod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
