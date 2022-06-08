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
    public partial class ScoreForm : Form
    {
        CourseClass course = new CourseClass();
        StudentClass student = new StudentClass();
        ScoreClass score = new ScoreClass();
        public ScoreForm()
        {
            InitializeComponent();
        }
       
        private void ScoreForm_Load(object sender, EventArgs e)
        {
           


                // to show score data on datagridview
                showScore();
        }
            public void showScore()
            {
                DataGridView_student.DataSource = score.getList(new MySqlCommand("SELECT * FROM `notee`"));
            }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_stdId.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Need score data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string idEtudiant = textBox_stdId.Text;
                int idModule = Convert.ToInt32(textBox3.Text);
              double cc1 = Convert.ToDouble(textBox_score.Text);
                double cc2 = Convert.ToDouble(textBox1.Text);
               double exam = Convert.ToDouble(textBox2.Text);

                double moyen = 0;
                moyen += cc1 * 0.25 + cc2 * 0.25 + exam * 0.5;
                textBox4.Text = moyen.ToString();

                DBconnect connect = new DBconnect();
                connect.openConnect();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `etudiant` WHERE cne = '" + textBox_stdId.Text + "'", connect.getconnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                int i = ds1.Tables[0].Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("le cne saisie ne corespond à aucun etudiant, réessayez", "Ajouter note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM `module` WHERE id = '" + textBox3.Text + "'", connect.getconnection);
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

                        if (score.insertNote(idEtudiant, idModule, cc1, cc2, exam))
                        {
                            showScore();
                            button_clear.PerformClick();
                            MessageBox.Show("New score added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Note not added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
               
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_score.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
           


        }

        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            //textBox_stdId.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
        }

        private void button_sStudent_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = student.getList(new MySqlCommand("SELECT * FROM `etudiant`"));
        }

        private void button_sScore_Click(object sender, EventArgs e)
        {
            showScore();
        }

        private void textBox_stdId_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_stdId_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
