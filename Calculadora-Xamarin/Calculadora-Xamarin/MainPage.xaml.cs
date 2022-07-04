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
        int[] n = new int[6];
        int[] n2 = new int[30];
        int i = 0;
        int o = 0;
        int g = 0;

        // Valor 01
        //float n1 = 0;

        // Representação do Valor 1
        //string sn1 = "";

        //Valor 2

        // Representação do Valor 2
        //string sn2 = "";

        //Índice de operação matemática
        int[] op = new int[5];

        // Resultado do cálculo
        float resultado = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        // Evento de botões numéricos
        private void ButtonNumero(object sender, EventArgs e)
        {
            try
            {
                if(g <= 4)
                {
                    Button button1 = (Button)sender;
                    //Armazena o valor passado pelo CommandParameter
                    int NumPressed = int.Parse(button1.CommandParameter.ToString());

                    if (n[i] != 0)
                    {
                        n2[i] = NumPressed;

                        n[i] = int.Parse(n[i].ToString() + n2[i].ToString());

                        if (o > 0)
                        {
                            Lbl_Resultado.Text = Lbl_Resultado.Text + n2[i].ToString();

                        }
                        else
                        {
                            Lbl_Resultado.Text = n[i].ToString();

                        }
                    }
                    else
                    {
                        n[i] = NumPressed;

                        if (o > 0)
                        {

                            Lbl_Resultado.Text = Lbl_Resultado.Text + n[i].ToString();

                        }
                        else
                        {
                            Lbl_Resultado.Text = n[i].ToString();
                        }
                    }
                }
                else
                {
                    DisplayAlert("Alerta", "Número excedente a 5 digitos", "OK");
                }
                
                g++;
                

            } catch (Exception ex)
            {

                DisplayAlert("Alerta!", ex.Message, "OK");
            }
        }



        // Evento de botões operacionais
        private void ButtonOperacoes(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            string operacao = button1.CommandParameter.ToString();
            string simbolo = "";


            switch (operacao)
            {
                case "soma":
                    op[o] = 1;
                    simbolo = " + ";
                    break;
                case "subt":
                    op[o] = 2;
                    simbolo = " - ";
                    break;
                case "mult":
                    op[o] = 3;
                    simbolo = " x ";
                    break;
                case "div":
                    simbolo = " / ";
                    op[o] = 4;
                    break;

            }

            if (Lbl_Resultado.Text != "0")
            {

                Lbl_Resultado.Text = Lbl_Resultado.Text + simbolo;
            }

            i++;
            o++;
            g = 0;
        }

        // Evento do botão resultado
        private void ButtonResult(object sender, EventArgs e)
        {

            for (o = 0; o < i; o++)
            {
                if (resultado == 0)
                {
                    switch (op[o])
                    {
                        case 1:
                            resultado = n[0] + n[o+1];
                            break;

                        case 2:
                            resultado = n[0] - n[o+1];
                            break;

                        case 3:
                            resultado = n[0] * n[o+1];
                            break;

                        case 4:
                            resultado = n[0] / n[o+1];
                            break;
                        case 5:
                            resultado = (n[0] / 100) * n[o+1];
                            break;
                    }
                }
                else
                {
                    switch (op[o])
                    {
                        case 1:
                            resultado = resultado + n[o+1];
                            break;

                        case 2:
                            resultado = resultado - n[o+1]; ;
                            break;

                        case 3:
                            resultado = resultado * n[o+1];
                            break;

                        case 4:
                            resultado = resultado / n[o+1];
                            break;
                        case 5:
                            resultado = (resultado / 100) * n[o+1];
                            break;
                    }
                }
            }

            Lbl_Resultado.Text = resultado.ToString();
            LimpaTudo();


        }

        // Evento botões diversos
        private void ButtonDiversos(object sender, EventArgs e)
        {
            try
            {
                Button button1 = (Button)sender;
                int d = int.Parse(button1.CommandParameter.ToString());

                switch (d)
                {
                    // Botão AC
                    case 1:
                        Lbl_Resultado.Text = "0";
                        resultado = 0;

                        LimpaTudo();



                        break;
                    // Botão Inverter sinal
                    case 2:

                        break;
                    // Botão Vírgula
                    case 3:

                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }



        }

        public void LimpaTudo()
        {
            for (i = 0; i <= 5; i++)
            {
                n[i] = 0;
            }

            for (o = 0; o <= 4; o++)
            {
                op[o] = 0;
            }

            i = 0;
            o = 0;
            g = 0;
        }



    }
}


