using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora_Xamarin
{
    public partial class MainPage : ContentPage
    {
        // Valor variavel
        int[] n = new int[30];
        int i = 0;
        int o = 0;

        // Valor 01
        float n1 = 0;

        // Representação do Valor 1
        string sn1 = "";

        //Valor 2
        float n2 = 0;

        // Representação do Valor 2
        string sn2 = "";

        //Índice de operação matemática
        int[] op = new int[5];

        // Resultado do cálculo
        float resultado = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        // Método para botões numéricos
        private void ButtonNumero(object sender, EventArgs e)
        {
            try
            {
                Button button1 = (Button)sender;
                //Armazena o valor passado pelo CommandParameter
                int NumPressed = int.Parse(button1.CommandParameter.ToString());

                n[i] = NumPressed;
                i++;



                // Operação exclusiva do número 0 
                if (NumPressed == 0)
                {
                    if (op[i] == 0)
                    {
                        // Nenhum valor atribuído ao primeiro número
                        if (n[i] == 0)
                        {
                            sn1 = n1.ToString() + "0";
                            Lbl_Resultado.Text = Lbl_Resultado.Text + "0";
                        }
                    }
                    else
                    {
                        // Nenhum valor atribuído ao segundo número
                        if (n[i] != 0)
                        {
                            sn2 = sn2 + "0";

                            Lbl_Resultado.Text = Lbl_Resultado.Text + "0";
                        }
                    }
                }
                //Operação para os números de 1 a 9
                else
                {
                    if (op[i] == 0)
                    {
                        //if (resultado != 0)
                        //{
                        //    n1 = resultado;
                        //}
                        // Nenhum valor atribuído ao primeiro número
                        if (n[i] == 0)
                        {

                            sn1 = n[i].ToString();
                            Lbl_Resultado.Text = NumPressed.ToString();
                        }
                        else
                        {
                            sn1 = sn1 + NumPressed.ToString();
                            Lbl_Resultado.Text = Lbl_Resultado.Text + NumPressed.ToString();
                        }

                    }
                    else
                    {
                        //if (resultado != 0)
                        //{
                        //    n1 = resultado;
                        //}
                        // Nenhum valor atribuído ao segundo número
                        if (n[i] == 0)
                        {

                            sn2 = n[i].ToString();
                            Lbl_Resultado.Text = Lbl_Resultado.Text + NumPressed.ToString();
                        }
                        else
                        {
                            sn2 = sn2 + NumPressed.ToString();
                            Lbl_Resultado.Text = Lbl_Resultado.Text + NumPressed.ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta!", ex.Message, "OK");
            }
        }



    }
}


