using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoC_Sharp
{
    public partial class Form1 : Form
    {
        int Xplayer = 0;
        int Oplayer = 0;
        int empates = 0;
        int rodadas = 0;

        bool turno = true;
        bool jogoFinal = false;

        string[] text = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogoFinal == false)
                if (turno)
                {
                    btn.Text = "X";
                    text[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    text[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }
        }
        void Vencedor(int PlayerVencedor)
        {
            jogoFinal = true;

            if (PlayerVencedor == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador 'X' ganhou.");
                turno = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador 'O' ganhou.");
                turno = false;
            }
        }
        void Checagem(int ChecagemPlayer)
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
                suporte = "X";
            else
                suporte = "O";

            //----Checagem Horizontal:
            for (int h = 0; h < 8; h += 3)
                if (suporte == text[h])
                    if (text[h] == text[h + 1] && text[h] == text[h + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
            //----Checagem Vertical:
            for (int v = 0; v < 3; v++)
                if (suporte == text[v])
                    if (text[v] == text[v + 3] && text[v] == text[v + 6])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
            //----Checagem Diagonal Principal
            if (text[0] == suporte)
                if (text[0] == text[4] && text[0] == text[8])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                }
            //----Checagem Diagonal Secundária
            if (text[2] == suporte)
                if (text[2] == text[4] && text[2] == text[6])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                }
            if (rodadas == 9 && jogoFinal == false)
            {
                empates++;
                empate.Text = Convert.ToString(empates);
                MessageBox.Show("Empate!");
                jogoFinal = true;
                return;
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";

            rodadas = 0;
            jogoFinal = false;
            for (int i = 0; i < 9; i++)
            {
                text[i] = "";
            }
        }
    }
}