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
    public partial class ManageStudentForm : Form
    {
        StudentClass student = new StudentClass();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            showTable();
            comboBoxSpec.DataSource = student.getSpecialite(new MySqlCommand("SELECT * FROM `specialite`"));
            comboBoxSpec.DisplayMember = "nom";
            comboBoxSpec.ValueMember = "nom";

        }
        // To show student list in DatagridView
        public void showTable()
        {

            DataGridView_student.DataSource = student.getStudentlist(new MySqlCommand("SELECT * FROM `etudiant`"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        //Display student data from student to textbox
        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            textBox_CNE.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            textBox_Fname.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            textBox_Lname.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            textBox_phone.Text = DataGridView_student.CurrentRow.Cells[3].Value.ToString();
            textBox_mail.Text = DataGridView_student.CurrentRow.Cells[4].Value.ToString();
          
            if (DataGridView_student.CurrentRow.Cells[5].Value.ToString() == "Homme")
                radioButton_male.Checked = true;
            else
                radioButton_female.Checked = true;

            // textBox_phone.Text = DataGridView_student.CurrentRow.Cells[5].Value.ToString();

            // textBox_CNE.Text = DataGridView_student.CurrentRow.Cells[7].Value.ToString();
            textBox_address.Text = DataGridView_student.CurrentRow.Cells[6].Value.ToString();
            // textBox_mail.Text = DataGridView_student.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker1.Value = (DateTime)DataGridView_student.CurrentRow.Cells[8].Value;
            byte[] img = (byte[])DataGridView_student.CurrentRow.Cells[9].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox_student.Image = Image.FromStream(ms);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            textBox_CNE.Clear();
            textBox_mail.Clear();

            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_student.Image = null;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            // browse photo from your computer
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(opf.FileName);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = student.searchStudent(textBox_search.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        //create a function to verify
        bool verify()
        {
            if ((textBox_Fname.Text == "") || (textBox_Lname.Text == "") ||
                (textBox_phone.Text == "") || (textBox_address.Text == "") ||
                (textBox_CNE.Text == "") || (textBox_mail.Text == "") ||
                (pictureBox_student.Image == null))
            {
                return false;
            }
            else
                return true;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // update student record
            //int id = Convert.ToInt32(textBox_id.Text);
            string id = textBox_id.Text;
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox_phone.Text;
            string address = textBox_address.Text;
            string cne = textBox_CNE.Text;
            string mail = textBox_mail.Text;
           
            string nomspec = comboBoxSpec.Text;
            string gender = radioButton_male.Checked ? "Homme" : "Femme";
            //pour reccuperer le id de specialité
            DBconnect connect = new DBconnect();
            connect.openConnect();
            MySqlCommand cmd = new MySqlCommand("SELECT id FROM `specialite` WHERE nom = '" + nomspec + "'", connect.getconnection);
            int idspecialite = Convert.ToInt32(cmd.ExecuteScalar());

            //we need to check student age between 17 and 100

            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            /*
            if ((this_year - born_year) < 17 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be between 17 and 100 to join the our university", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            if (verify())
            {
                try
                {
                    // to get photo from picture box
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    //string cne,string fname, string lname, string phone, string mail, string gender, string address, int idspecialite , DateTime bdate,byte[] img
                    if (student.updateStudent(cne, fname, lname, phone, mail, gender, address,idspecialite,bdate,img))
                    {
                        showTable();
                        MessageBox.Show("Student data update", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Empty Field", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //remove the selected Student
            String id = textBox_CNE.Text;
            //Show a confirmation message before delete the student
            if (MessageBox.Show("Are you sure you want to remove this student", "Remove Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (student.deleteStudent(id))
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
