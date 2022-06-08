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

namespace Transparent_Form
{
    public partial class LoginForm : Form
    {
        StudentClass student = new StudentClass();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Transparent;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
                      
    
            if (textBox_usrname.Text == "" || textBox_password.Text == "" || comboBoxType.Text == "")
            {
                MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string uname = textBox_usrname.Text;
                string pass = textBox_password.Text;
                string type = comboBoxType.Text;

                //admin scolarité
                if (type == "Administrateur Scolarité")
                {
                    DataTable table = student.getList(new MySqlCommand("SELECT * FROM `user` WHERE `username`= '" + uname + "' AND `password`='" + pass + "' AND type = '" + type + "'"));
                    if (table.Rows.Count > 0)
                    {
                        MainForm main = new MainForm();
                        this.Hide();
                        main.Show();
                    }

                }
                //admin

                else if (type == "Administrateur")
                {
                    DataTable table = student.getList(new MySqlCommand("SELECT * FROM `user` WHERE `username`= '" + uname + "' AND `password`='" + pass + "' AND type = '" + type + "'"));
                    if (table.Rows.Count > 0)
                    {
                        AdminForm admin = new AdminForm();
                        this.Hide();
                        admin.Show();
                    }
                }

                else if (type == "Professeur")
                {
                    DataTable table = student.getList(new MySqlCommand("SELECT * FROM `professeur` WHERE `nom`= '" + uname + "' AND `cin`='" + pass + "'"));
                    if (table.Rows.Count > 0)
                    {


                        ClassSession.cinProf = pass;
                        FormProf main = new FormProf();
                        this.Hide();
                        main.Show();



                    }
                  
                }
              
                else if (type == "Étudiant")
                {
                    
                    DataTable table = student.getList(new MySqlCommand("SELECT * FROM `etudiant` WHERE `nom`= '" + uname + "' AND `cne`= '" + pass + "' "));
                    if (table.Rows.Count > 0)
                    {


                        DBconnect connect = new DBconnect();
                        connect.openConnect();
                        MySqlCommand cmd = new MySqlCommand("SELECT cne FROM `etudiant` WHERE `nom`= '" + uname + "' AND `cne`='" + pass + "'", connect.getconnection);
                        object result = cmd.ExecuteScalar();
                        String id = Convert.ToString(result);


                        Static_class.UserID = id;

                        Espace_Etudiant main = new Espace_Etudiant();
                        this.Hide();
                        main.Show();

                    }
   
                }

                else
                {
                    MessageBox.Show("Your username and password are not exists", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void textBox_usrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
