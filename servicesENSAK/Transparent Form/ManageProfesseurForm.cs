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
    public partial class ManageProfesseurForm : Form
    {
        ProfesseurClass prof = new ProfesseurClass();
        public ManageProfesseurForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
        // To show student list in DatagridView
        public void showTable()
        {
            DataGridView_student.DataSource = prof.getProfesseurlist(new MySqlCommand("SELECT * FROM `professeur`"));
           
        }

        //Display student data from student to textbox
        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            textBox_Fname.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            textBox_Lname.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            textBox_phone.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = DataGridView_student.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = DataGridView_student.CurrentRow.Cells[4].Value.ToString();

            if
                 (DataGridView_student.CurrentRow.Cells[5].Value.ToString() == "Male")
                radioButton_male.Checked = true;



       else if
                (DataGridView_student.CurrentRow.Cells[5].Value.ToString() == "Female")
                radioButton_female.Checked = true;

            textBox2.Text = DataGridView_student.CurrentRow.Cells[6].Value.ToString();
            textBox4.Text = DataGridView_student.CurrentRow.Cells[7].Value.ToString();
            textBox_id.Text = DataGridView_student.CurrentRow.Cells[8].Value.ToString();

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

  
        private void button_search_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Nom")
            {
               
                DataGridView_student.DataSource = prof.searchProfesseur1(textBox_search.Text);
            }
            else if (comboBox1.Text == "Prenom")
            {
                DataGridView_student.DataSource = prof.searchProfesseur2(textBox_search.Text);
            }
            else if (comboBox1.Text == "Matiere")
            {
                DataGridView_student.DataSource = prof.searchProfesseur3(textBox_search.Text);
            }
            else if (comboBox1.Text == "Sexe")
            {
                DataGridView_student.DataSource = prof.searchProfesseur4(textBox_search.Text);
            }
        }
        //create a function to verify
        bool verify()
        {
            if ((textBox_Fname.Text == "") || (textBox_Lname.Text == "") ||
                (textBox_phone.Text == "") || (textBox_id.Text == "") ||
                (textBox1.Text == "") ||
                (textBox2.Text == "") ||
                (textBox3.Text == "") ||
                (textBox4.Text == "") )
            {
                return false;
            }
            else
                return true;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // update student record
          
            string cin = textBox_Fname.Text;
            string nom = textBox_Lname.Text;
            string prenom = textBox_phone.Text;
            string tel = textBox1.Text;
            string email = textBox3.Text;
            string mdp = textBox2.Text;
            string matiere = textBox4.Text;
            string titre = textBox_id.Text;
            string sexe = radioButton_male.Checked ? "Male" : "Female";


            //we need to check student age between 10 and 100

           
         if (verify())
            {
                try
                {
                    // to get photo from picture box
                   
                    if (prof.updateProfesseur(cin,nom,prenom, tel, email,sexe, mdp, matiere, titre))
                    {
                        showTable();
                        MessageBox.Show("teacher data update", "Update teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_clear.PerformClick();
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update teacher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //remove the selected Student
            string cin = textBox_Fname.Text;
            //Show a confirmation message before delete the student
            if (MessageBox.Show("Are you sure you want to remove this teacher", "Remove teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (prof.deleteProfesseur(cin))
                {
                    showTable();
                    MessageBox.Show("Student Removed", "Remove student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_clear.PerformClick();
                }
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Lname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
