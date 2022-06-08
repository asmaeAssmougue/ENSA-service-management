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
    public partial class SpecialiteForm : Form
    {
        SpecialiteClass specialite = new SpecialiteClass();
        public SpecialiteForm()
        {
            InitializeComponent();
            showData();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_Cname.Text == "")
            {
                MessageBox.Show("Need Course data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string nom = textBox_Cname.Text;
                string niveaux = "";

                // recuperer les niveaux :
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        //coché
                        niveaux += checkedListBox1.Items[i].ToString() + ",";
                    }
                }


                if (specialite.insertSpecialite(nom, niveaux))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("New specialite inserted", "Add Specialite", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Specialite not insert", "Add Specialite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Cname.Clear();
           /* checkedListBox1.ClearSelection();
            foreach (ListItem li in checkedListBox1.Items)
            {
                li.Selected = false;
            } */
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            //to show course list on datagridview
            DataGridView_course.DataSource = specialite.getSpecialite(new MySqlCommand("SELECT * FROM `specialite`"));
        }

        private void button_clear_Click_1(object sender, EventArgs e)
        {
            textBox_Cname.Clear();

            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            if (textBox_Cname.Text == "")
            {
                MessageBox.Show("Need Course data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string nom = textBox_Cname.Text;
                string niveaux = "";

                // recuperer les niveaux :
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        //coché
                        niveaux += checkedListBox1.Items[i].ToString() + ",";
                    }
                }


                if (specialite.insertSpecialite(nom, niveaux))
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