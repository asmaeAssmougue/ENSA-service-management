using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Transparent_Form
{
    public partial class ModuleForm : Form

    {
        ModuleClass module = new ModuleClass();
        public ModuleForm()
        {
            InitializeComponent();
            showData();
        }
        private void ModuleForm_Load(object sender, EventArgs e)
        {
            showData();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_module.Text == "" || textBox_nomprof.Text == "" || textBox_prenomprof.Text == "")
            {
                MessageBox.Show("veuiller remplir tous les champs", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string nom = textBox_module.Text;
                string nom_prof = textBox_nomprof.Text;
                string prenom_prof = textBox_prenomprof.Text;


                if (module.InsertModule(nom, nom_prof, prenom_prof))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("Nouveau module est inséré avec succés", "Ajout Module", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Module non inséré ", "Ajout modulee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showData()
        {
            //to show course list on datagridview
            DataGridView_module.DataSource = module.getlist(new MySqlCommand("SELECT * FROM `module`"));
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_module.Clear();
            textBox_nomprof.Clear();
            
            textBox_prenomprof.Clear();
        }

        private void ModuleForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
