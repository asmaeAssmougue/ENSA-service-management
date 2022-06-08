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
    public partial class CourseForm : Form
    {
        CourseClass course = new CourseClass();
        public CourseForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_Cname.Text == "" || textBox_Chour.Text == "")
            {
                MessageBox.Show("Need Course data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                int id_module = Convert.ToInt32(textBox_Cname.Text);
                string cin_prof = textBox_id.Text;
                int hour = Convert.ToInt32(textBox_Chour.Text);

                DBconnect connect = new DBconnect();
                connect.openConnect();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `professeur` WHERE cin = '" + textBox_id.Text + "'", connect.getconnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                int i = ds1.Tables[0].Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("le cin saisie ne corespond à aucun etudiant, réessayez", "Ajouter note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM `module` WHERE id = '" + textBox_Cname.Text + "'", connect.getconnection);
                    MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                    DataSet ds12 = new DataSet();
                    da2.Fill(ds12);
                    int j = ds12.Tables[0].Rows.Count;
                    if (j == 0)
                    {
                        MessageBox.Show("le id_module saisie ne corespond à aucun module, réessayez", "Ajouter note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (course.insetCourse(id_module, cin_prof, hour))
                        {
                            showData();
                            button_clear.PerformClick();
                            MessageBox.Show("New course inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Course not insert", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Cname.Clear();
            textBox_Chour.Clear();
            textBox_id.Clear();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            //to show course list on datagridview
            DataGridView_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `cours`"));
        }
    }
}
