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
using System.Data.SqlClient;

namespace Transparent_Form
{
    public partial class RegisterForm : Form
    {
        StudentClass student = new StudentClass();
        

        public RegisterForm()
        {
            InitializeComponent();
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

        
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            showTable();
            comboBoxspec.DataSource = student.getSpecialite(new MySqlCommand("SELECT * FROM `specialite`"));
            comboBoxspec.DisplayMember = "nom";
            comboBoxspec.ValueMember = "nom";
            //comboBoxspeci
        }
        // To show student list in DatagridView
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentlist(new MySqlCommand("SELECT * FROM `etudiant`"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            // browse photo from your computer
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(opf.FileName);

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // add new student
            //string specialite = comboBoxspec.SelectedValue.ToString();
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox_phone.Text;
            string address = textBox_address.Text;
            String cne = textBox_CNE.Text;
            string mail = textBox_mail.Text;
            string specialite=comboBoxspec.SelectedValue.ToString();
            string nomspec = comboBoxspec.Text;


            string gender = radioButton_male.Checked ? "Homme" : "Femme";
            //pour reccuperer le id du specialité
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
                MessageBox.Show("The student age must be between 17 and 100", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            if (verify())
            {
                try
                {
                    //string specialite = comboBoxspec.SelectedValue.ToString();
                    // to get photo from picture box
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (student.insertStudent(cne,fname, lname, phone,mail,gender,address,idspecialite,bdate,img))
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
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
             textBox_phone.Clear();
            textBox_address.Clear();
            textBox_CNE.Clear();
            textBox_mail.Clear();
            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_student.Image = null;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxspec_SelectedIndexChanged(object sender, EventArgs e)
        {
           // specialite = comboBoxspec.SelectedValue.ToString();

        }
    }
}
