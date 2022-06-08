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
    public partial class ManageSpecialiteForm : Form
    {
        SpecialiteClass specialite = new SpecialiteClass();
        public ManageSpecialiteForm()
        {
            InitializeComponent();
            showData();
        }

        private void ManagespecialiteForm_Load(object sender, EventArgs e)
        {
            showData();

        }
        // Show data of the specialite 
        private void showData()
        {
            //to show specialite list on datagridview
            DataGridView_specialite.DataSource = specialite.getSpecialite(new MySqlCommand("SELECT * FROM `specialite`"));
        }


        private void button_search_Click(object sender, EventArgs e)
        {
            //To Search specialite and show on datagridview
            String search = textBox_search.Text;
            DataGridView_specialite.DataSource = specialite.getSpecialite(new MySqlCommand("SELECT * FROM `specialite` WHERE CONCAT(`nom`)LIKE '%" + search + "%' or CONCAT(`niveau_etude`)LIKE '%" + search + "%'"));
            textBox_search.Clear();
        }


        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Cname.Clear();
            textBox_id.Clear();

            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need specialite Id", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(textBox_id.Text);
                    if (specialite.deletSpecialite(id))
                    {
                        showData();
                        button_clear.PerformClick();
                        MessageBox.Show("specialite Deleted", "Removed specialite", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Removed specialite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (textBox_Cname.Text == "" || textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need specialite data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_id.Text);
                string nom = textBox_Cname.Text;
                string niveaux = "";

                // recuperer les niveaux :
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        //coché
                        niveaux += checkedListBox1.Items[i].ToString() + ",";
                    }
                }


                if (specialite.updateSpecialite(id, nom, niveaux))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("specialite update successfuly", "Update specialite", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error-specialite not Edit", "Update specialite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_specialite_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_id.Text = DataGridView_specialite.CurrentRow.Cells[0].Value.ToString();
            textBox_Cname.Text = DataGridView_specialite.CurrentRow.Cells[1].Value.ToString();

            String[] niveaux = DataGridView_specialite.CurrentRow.Cells[2].Value.ToString().Split(',');  // tableau des niveaux

            

           // string test = "";

            foreach (string n in niveaux)  // pour chaque niveau trouvé dans la colonne, on le compare avec tous les éléments du checkbox
            {
                string niveau = n.Trim();   // supprimer les espaces autour

                foreach (int i in Enumerable.Range(0, 4))
                {
                    if (checkedListBox1.Items[i].ToString() == niveau)      // si égaux = si le niveau existe
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);   // check son indice
                       // test += checkedListBox1.Items[i].ToString() + "-";
                    }
                }

            }

            //textBox1.Text = test;
        }
    }
}
