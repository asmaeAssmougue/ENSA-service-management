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
    public partial class Consulter_Abscence : Form
    {
        Abscence_Class abscence = new Abscence_Class();
        public Consulter_Abscence()
        {
            InitializeComponent();
            showData();
        }
        private void showData()
        {
            //to show course list on datagridview '"+ var +"'
            string id_etudiant = Static_class.UserID;

            dataGridView_abscence.DataSource = abscence.getlist(new MySqlCommand("SELECT * FROM `abscence` WHERE cne_student= '" + id_etudiant + "' "));
            MessageBox.Show(id_etudiant);
        }

        private void dataGridView_note_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showData();
        }
    }
}
