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
    public partial class RegisterProf : Form
    {
        ProfesseurClass prof = new ProfesseurClass();
        public RegisterProf()
        {
            InitializeComponent();
        }

 

        //create a function to verify
        bool verify()
        {
            if ((textBox_Fname.Text == "") || (textBox_Lname.Text == "") ||
              (textBox_phone.Text == "") || (textBox_id.Text == "") ||
              (textBox1.Text == "") ||
              (textBox2.Text == "") ||
              (textBox3.Text == "") ||
              (textBox4.Text == ""))

            {
                return false;
            }
            else
                return true;
        }


        private void RegisterForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
        // To show student list in DatagridView
        public void showTable()
        {
            DataGridView_student.DataSource = prof.getProfesseurlist(new MySqlCommand("SELECT * FROM `professeur`"));
        }

    

        private void button_add_Click(object sender, EventArgs e)
        {
            string cin = textBox_Fname.Text;
            string nom = textBox_Lname.Text;
            string prenom = textBox_phone.Text;
            string tel = textBox1.Text;
            string email = textBox3.Text;
            string mdp = textBox2.Text;
            string matiere = textBox4.Text;
            string titre = textBox_id.Text;
            string sexe = radioButton_male.Checked ? "Male" : "Female";
             if (verify())
            {
                try
                {
                  
                    if (prof.insertProfesseur(cin, nom, prenom, tel, email, sexe, mdp, matiere, titre))
                    {
                        showTable();
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox1.Clear();
            radioButton_male.Checked = true;

            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void textBox_Lname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
