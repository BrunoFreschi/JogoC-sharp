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
                        MessageBox.Show("Horizontal!");
                        return;
                    }
            //----Checagem Vertical:
            for (int v = 0; v < 3; v++)
                if (suporte == text[v])
                    if (text[v] == text[v + 3] && text[v] == text[v + 6])
                    {
                        MessageBox.Show("Vertical!");
                        return;
                    }
        }
    }
}
