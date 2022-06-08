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
using System.Data;

namespace Transparent_Form
{
    public partial class ManageModuleForm : Form
    {
        ModuleClass module = new ModuleClass();
        private void ManageModuleForm_Load(object sender, EventArgs e)
        {
            showData();

        }
        public ManageModuleForm()
        {
            InitializeComponent();
            showData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void showData()
        {
            //to show course list on datagridview
            DataGridView_update.DataSource = module.getlist(new MySqlCommand("SELECT * FROM `module`"));
        }

        private void button_update_Click(object sender, EventArgs e)
        {

            if (textBox_module.Text == "" || textBox_cinprof.Text == "")
            {
                MessageBox.Show("veuiller choisir une ligne qui contient des données", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int selectedIndex = DataGridView_update.SelectedRows[0].Index;
                int id = int.Parse(DataGridView_update.Rows[selectedIndex].Cells["id"].Value.ToString());

                /*int id = Convert.ToInt32(textBox_id.Text);*/

                string nom = textBox_module.Text;

                string cinprof = textBox_cinprof.Text;






                if (module.updatemodule(id, nom, cinprof))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("course update successfuly", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error-Course not Edit", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_module.Clear();
            textBox_cinprof.Clear();
        }

        private void button_search_Click(object sender, EventArgs e)
        {

            DataGridView_update.DataSource = module.searchmodule(textBox_search.Text);
            DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn();
            imageColumn = (DataGridViewTextBoxColumn)DataGridView_update.Columns[2];



        }

        private void DataGridView_update_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_update_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedRow = 0;
            SelectedRow = e.RowIndex;
            if (SelectedRow != -1)
            { //NomRep,TypeClient,Nom,Prénom, Tel,Portable,Fax,Email,Adresse, Ville,Pays
                //
                DataGridViewRow row = DataGridView_update.Rows[SelectedRow];
                textBox_id.Text = row.Cells["id"].Value.ToString();
                textBox_module.Text = row.Cells["nom"].Value.ToString();
                textBox_cinprof.Text = row.Cells["cin_prof"].Value.ToString();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                MessageBox.Show("veuiller remplir le champ de lidentifiant du module ", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_id.Text);
                if (MessageBox.Show("Are you sure you want to remove this score", "Delete Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (module.deletemodule(id))
                    {
                        showData();
                        MessageBox.Show("Ce module a bien été supprimer", "Supprimer Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_clear.PerformClick();
                    }
                }

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
