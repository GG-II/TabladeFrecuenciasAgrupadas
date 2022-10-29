using Microsoft.VisualBasic;
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
    public partial class Login : Form
    {
        Mmenu ventana = new Mmenu();

        public Login()
        {
            InitializeComponent();
        }

        private void btIniciar_Click(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Admin"){
                if (tbContra.Text == "1234")
                {
                    MessageBox.Show("Sesión iniciada correctamente");
                    ventana.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
            }
            else
            {
                MessageBox.Show("Usuario y contraseña incorrectos");
            }
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
