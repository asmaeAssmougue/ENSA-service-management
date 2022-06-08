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
    public partial class Espace_Etudiant : Form
    {
        public Espace_Etudiant()
        {
            InitializeComponent();
        }
        //to show register form in mainform
        private Form activeForm = null;
        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Consulter_Note f = new Consulter_Note();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulter_Abscence f = new Consulter_Abscence();
            f.Show();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
        }
    }
}
