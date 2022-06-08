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
    public partial class Consulter_Note : Form
    {
        NoteClass note = new NoteClass();
        public Consulter_Note()
        {
            InitializeComponent();
            showData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void showData()
        {
            string id_etudiant = Static_class.UserID;

            MessageBox.Show(id_etudiant);
            //to show course list on datagridview
            dataGridView_note.DataSource = note.getlist(new MySqlCommand("SELECT * FROM `notee` WHERE idEtudiant= '" + id_etudiant + "' " ));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
