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
    public partial class AdminForm : Form
    {
        StudentClass student = new StudentClass();
        CourseClass course = new CourseClass();
        Absence absence = new Absence();
        public AdminForm()
        {
            InitializeComponent();
            //customizeDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            studentCount();
            //populate the combobox with courses name
            comboBox_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_course.DisplayMember = "CourseName";
            comboBox_course.ValueMember = "CourseName";
        }

        //create a function to display student count
        private void studentCount()
        {
            //Display the values
            label_totalStd.Text = "Total Students : " + student.totalStudent();
            label_maleStd.Text = "Male : " + student.maleStudent();
            label_femaleStd.Text = "Female : " + student.femaleStudent();

        }

        /*
        private void customizeDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel_profsubmenu.Visible = false;
        }
        */

        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;
            if (panel_profsubmenu.Visible == true)
                panel_profsubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            // showSubmenu(panel_stdsubmenu);
        }
        
        private void button_registration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterProf());
            //...
            //..Your code
            //...
           // hideSubmenu();

        }

        private void button_manageStd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            //...
            //..Your code
            //...
           // hideSubmenu();
        }

        private void button_status_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
           // hideSubmenu();
        }


        //to show register form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
            studentCount();
        }

        private void button_exit_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_cmale.Text = "Male : " + student.exeCount("SELECT COUNT(*) FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE score.CourseName = '" + comboBox_course.Text + "' AND student.Gender = 'Male'");
            label_cfemale.Text = "Female : " + student.exeCount("SELECT COUNT(*) FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE score.CourseName = '" + comboBox_course.Text + "' AND student.Gender = 'Female'");
        }

        private void button_prof_Click(object sender, EventArgs e)
        {
           // showSubmenu(panel_profsubmenu);

        }

        private void button_registration_Click_1(object sender, EventArgs e)
        {
            openChildForm(new RegisterForm());
            //...
            //..Your code
            //...
           // hideSubmenu();
        }

        private void button_manageStd_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            //...
            //..Your code
            //...
           // hideSubmenu();
        }

        private void button2_Click(object sender, EventArgs e)  // ajouter prof
        {
            openChildForm(new RegisterProf());
            //...
            //..Your code
            //...
           // hideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageProfesseurForm());
            //...
            //..Your code
            //...
           // hideSubmenu();
        }

        private void button_exit_Click_2(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
        }
    }
}

