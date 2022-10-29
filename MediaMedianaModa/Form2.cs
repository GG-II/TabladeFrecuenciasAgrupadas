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
    public partial class Form2 : Form
    {
        Estadistica estad = new Estadistica();
        public Form2()
        {
            InitializeComponent();
        }

        public bool validacion()
        {
            bool noError = true;

            //Validacion si inputbox vacio
            if (cantfor.Text == String.Empty)
            {
                //Si esta vacío entra al if y manda un mensaje de error
                //con el icono de advertencia
                iconError.SetError(cantfor, "No dejar en blanco el inputbox");
                MessageBox.Show("Por favor, dijite una cantidad de numeros", "Cantidad de numeros en blanco");
                //retorna un falso
                noError = false;

            }
            else
            {
                try
                {
                    //Se convierte el numero que se digito en la caja de texto (que es string) a un entero
                    estad.Cantidad = Convert.ToInt32(cantfor.Text);
                }
                catch
                {
                    iconError.Clear();
                    iconError.SetError(cantfor, "Ingrese un numero valido");
                    MessageBox.Show("Tiene que ingresar un numero", "Error");
                    noError = false;
                }
            }
            return noError;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            double num = 0;
            if (validacion())
            {
                iconError.Clear();
                for (int i = 0; i < estad.Cantidad; i++)
                {
                    while (!double.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese los numeros", "Ingresar"), out num))
                    {
                        MessageBox.Show("Debe ser un numero", "Error");
                    }
                    while (num <= 0)
                    {
                        MessageBox.Show("Debe ser un numero mayor a cero", "Error");
                        while (!double.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese los numeros", "Ingresar"), out num))
                        {
                            MessageBox.Show("Debe ser un numero", "Error");
                        }
                    }

                    listaNumero.Items.Add(num);
                    estad.Numero = num;
                }
            }
        }

        private void calcular_Click(object sender, EventArgs e)
        {
            
            double[] vector = new double[estad.Cantidad];
            double[] vecOrdenado = new double[estad.Cantidad];

            for (int i = 0; i < estad.Cantidad; i++)
            {
                vector[i] = (double)listaNumero.Items[i];
            }
            vecOrdenado = estad.orden(vector);
            mediaV.Text = estad.MediaV(vecOrdenado).ToString();
            medianaV.Text = estad.Mediana(vecOrdenado).ToString();
            modaV.Text = estad.Moda(vecOrdenado).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mediaTxt.Text = estad.Media(estad.Numero, estad.Cantidad).ToString();
            midTxt.Text = estad.Media(estad.Numero, estad.Cantidad).ToString();
            
            double mediana = 0;
            //Sin uso de vectores
            //Mediana
            listaNumero.Sorted = true;
            int pos = estad.Cantidad / 2;
            if (estad.Cantidad % 2 == 0)
            {
                mediana = (((double)listaNumero.Items[pos - 1] + (double)listaNumero.Items[pos]) / 2.0);
            }
            else
            {
                mediana = (double)listaNumero.Items[pos];
            }
            medianaTxt.Text = mediana.ToString();
            //Sin vectores
            //Moda

            int conAnte = 0;
            int conDesp = 0;

            for (int i = 0; i < estad.Cantidad; i++)
            {
                double mPrimero = (double)listaNumero.Items[i];
                conDesp = 0;
                for (int j = 0; j < estad.Cantidad; j++)
                {
                    double mSegundo = (double)listaNumero.Items[j];
                    if (mPrimero == mSegundo)
                    {
                        conDesp++;
                    }
                }
                if (conDesp != 1)
                {
                    if (conAnte < conDesp)
                    {
                        conAnte = conDesp;
                        modaTxt.Text = mPrimero.ToString();
                    }
                }
            }

            //Rango
            double xmayor, xmenor;
            xmayor = xmenor = (double)listaNumero.Items[0];

            for (int i = 0; i < estad.Cantidad; ++i)
            {
                if ((double)listaNumero.Items[i] > xmayor) xmayor = (double)listaNumero.Items[i];
                if ((double)listaNumero.Items[i] < xmenor) xmenor = (double)listaNumero.Items[i];
            }
            double rang = xmayor - xmenor;
            xMenorTxt.Text = xmenor.ToString();
            xMayorTxt.Text = xmayor.ToString();
            rangoTxt.Text = rang.ToString();

            //Intervalo
            double kinter = Math.Sqrt(estad.Cantidad);
            int kinterv = (int)kinter+1;
            interTxt.Text = kinterv.ToString();

            //Amplitud
            double amp = Math.Round(rang / kinterv,2);
            ampliTxt.Text = amp.ToString();

            //Intervalos y límites
            double[] x = new double[kinterv];
            x[0] = xmenor + amp;
            for(int i= 1; i < kinterv; ++i)
            {
                x[i] = Math.Round(x[i - 1] + amp, 2);
            }

            Clases.Items.Add("(" + xmenor + " - " + x[0] + "]");
            for(int i=1; i < kinterv; ++i)
            {
                Clases.Items.Add("(" + x[i - 1] + " - " + x[i] + "]");
            }

            //Marca de clase
            double[] xi = new double[kinterv];
            xi[0] = Math.Round((xmenor + x[0]) / 2, 2);
            MarcaClase.Items.Add(xi[0]);
            for (int i=1; i < kinterv; ++i)
            {
                xi[i] = Math.Round((x[i-1] + x[i]) / 2, 2);
                MarcaClase.Items.Add(xi[i]);
            }

            //Frecuencia Absoluta
            int[] f = new int[kinterv];
                for (int j = 1; j < estad.Cantidad; ++j)
                {
                    if ((double)xmenor <= (double)listaNumero.Items[j])
                    {
                        if ((double)listaNumero.Items[j] < (double)x[0])
                        {
                            f[0]++;
                        }

                    }
                }

            for (int i=1; i < kinterv; ++i)
            {
                for (int j = 1; j < estad.Cantidad; ++j)
                {
                    if ((double)x[i-1] <= (double)listaNumero.Items[j])
                    {
                        if ((double)listaNumero.Items[j] < (double)x[i])
                        {
                            f[i]++;
                        }

                    }
                }
            }

            for (int i=0; i < kinterv; ++i)
            {
                frecuenciaAbsoluta.Items.Add(f[i]);
            }


            //Frecuencia Acumulada
            double[] fi = new double[kinterv];
            fi[0] = f[0];
            frecuenciaAcumulada.Items.Add(fi[0]);
            frecuenciaRelativaAcumulada.Items.Add(fi[0] / estad.Cantidad);
            for(int i=1; i < kinterv; ++i)
            {
                fi[i] = fi[i - 1] + f[i];
                frecuenciaAcumulada.Items.Add(fi[i]);
                frecuenciaRelativaAcumulada.Items.Add(fi[i] / estad.Cantidad);
            }

            //F
            double[] fxx = new double[kinterv];
            double fxxi = 0;
            for(int i=0; i < kinterv; ++i)
            {
                fxx[i] = f[i] * (Math.Pow((x[i]-estad.Media(estad.Numero, estad.Cantidad)),2));
                listBox1.Items.Add(fxx[i]);
                fxxi = fxxi + fxx[i];
            }

            //Variaza
            double vari = (fxxi / estad.Cantidad) / (fi[kinterv -1]-1);
            varianzaTxt.Text = vari.ToString();

            //Desviación
            double desv = Math.Sqrt(vari);
            desvTxt.Text = desv.ToString();

            mid1Txt.Text = ((estad.Media(estad.Numero, estad.Cantidad)) - desv).ToString();
            mid2Txt.Text = ((estad.Media(estad.Numero, estad.Cantidad)) + desv).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cantfor.Clear();
            listaNumero.Items.Clear();
            modaTxt.Clear();
            medianaTxt.Clear();
            mediaTxt.Clear();
            mediaV.Clear();
            medianaV.Clear();
            modaV.Clear();
            iconError.Clear();
            xMayorTxt.Clear();
            xMenorTxt.Clear();
            rangoTxt.Clear();
            ampliTxt.Clear();
            interTxt.Clear();
        }

        private void xMenorTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void graficbt_Click(object sender, EventArgs e)
        {

        }

        private void mediaTxt_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
