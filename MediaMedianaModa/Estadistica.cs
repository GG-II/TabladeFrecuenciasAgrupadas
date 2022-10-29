using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMedianaModa
{
    internal class Estadistica
    {
            int cantidad;
            int rang;
            double numero;

            double media;
            //Uso de vectores
            double mediav;
            double mediana;
            double moda;

            public int Cantidad { get => cantidad; set => cantidad = value; }
            public double Numero { get => numero; set => numero = value + numero; } //Para la mediana

            public double Media(double num, int cant)
            {
                media = num / cant;
                return media;
            }

            //Uso de vectores
            public double[] orden(double[] vec)
            {
                //Ordenamiento de vector
                for (int i = 0; i < cantidad; i++)
                {
                    for (int j = 0; j < cantidad - 1; j++)
                    {
                        if (vec[j] > vec[j + 1])
                        {
                            double aux;
                            aux = vec[j];
                            vec[j] = vec[j + 1];
                            vec[j + 1] = aux;
                        }
                    }
                }
                //
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine(vec[i]);
                }
                return vec;
            }

            public double MediaV(double[] vecme)
            {
                double sum = 0;
                for (int i = 0; i < cantidad; i++)
                {
                    sum += vecme[i];
                }
                mediav = sum / cantidad;
                return mediav;
            }

            public double Mediana(double[] vecm)
            {
                int pos = cantidad / 2;
                if (cantidad % 2 == 0)
                {
                    mediana = (vecm[pos - 1] + vecm[pos]) / 2;
                }
                else
                {
                    mediana = vecm[pos];
                }
                return mediana;
            }

            public double Moda(double[] vecmo)
            {
                int conAnte = 0;
                int conDesp = 0;

                for (int i = 0; i < cantidad; i++)
                {
                    double mPrimero = vecmo[i];
                    conDesp = 0;
                    for (int j = 0; j < cantidad; j++)
                    {
                        double msegundo = vecmo[j];
                        if (mPrimero == msegundo)
                        {
                            conDesp++;
                        }
                    }
                    if (conDesp != 1)
                    {
                        if (conAnte < conDesp)
                        {
                            conAnte = conDesp;
                            moda = mPrimero;
                        }
                    }
                }
                return moda;
            }
        }
    }



