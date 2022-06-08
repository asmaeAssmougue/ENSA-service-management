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
    public partial class ManageScoreForm : Form
    {
        CourseClass course = new CourseClass();
        ScoreClass score = new ScoreClass();
        public ManageScoreForm()
        {
            InitializeComponent();
        }

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            //populate the combobox with courses name
           
            
           
            // to show score data on datagridview
            showScore();
        }
        public void showScore()
        {
            DataGridView_score.DataSource = score.getList(new MySqlCommand("SELECT * FROM `notee`"));
       }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (textBox_stdId.Text == "" || textBox_score.Text == "")
            {
                MessageBox.Show("Need score data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string idEtudiant = textBox_stdId.Text ;
                int idModule = Convert.ToInt32(textBox3.Text);
                double cc1 = Convert.ToDouble( textBox_score.Text);
                double cc2 = Convert.ToDouble(textBox1.Text);
                double exam = Convert.ToDouble(textBox2.Text);

                double moyen = 0;
                moyen += cc1 * 0.25 + cc2 * 0.25 + exam * 0.5;
                textBox4.Text = moyen.ToString();
                if (score.updateNote(idEtudiant,idModule,cc1,cc2,exam))
                {
                    //showScore();
                    showScore();
                        MessageBox.Show("Score Edited Complete", "Update Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         button_clear.PerformClick();

                      
                }
                else
                {
                        MessageBox.Show("Score not edit", "Update Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
           
            if (textBox_stdId.Text == "")
            {
                MessageBox.Show("Field Error- we need student id", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string id = Convert.ToString(textBox_stdId.Text);
                if (MessageBox.Show("Are you sure you want to remove this score", "Delete Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (score.deleteNote(id))
                    {
                        //showScore();
                        MessageBox.Show("Score Removed", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_clear.PerformClick();
                    }
                }

            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_score.Clear();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void DataGridView_course_Click(object sender, EventArgs e)
        {



            // textBox_stdId = DataGridView_score.CurrentRow.Cells[0].Value.ToString();
            textBox_stdId.Text = DataGridView_score.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = DataGridView_score.CurrentRow.Cells[2].Value.ToString();
            textBox_score.Text = DataGridView_score.CurrentRow.Cells[3].Value.ToString();

            textBox1.Text = DataGridView_score.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = DataGridView_score.CurrentRow.Cells[5].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_score.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId, student.StdFirstName, student.StdLastName, score.CourseName, score.Score, score.Description FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE CONCAT(student.StdFirstName, student.StdLastName, score.CourseName)LIKE '%"+textBox_search.Text+"%'"));
            
        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_stdId_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_score_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
