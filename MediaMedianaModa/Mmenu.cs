using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaMedianaModa
{
    public partial class Mmenu : Form
    {
        Form2 MMM = new Form2();
        Form3 Integrantes = new Form3();
        Form4 Aprende = new Form4();
        public Mmenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MMM.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aprende.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Integrantes.Visible = true;
        }

        private void finsesion_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Sesión finalizada");
            Application.Exit();
        }
    }
}
