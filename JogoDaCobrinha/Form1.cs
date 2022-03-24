using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaCobrinha
{
    public partial class Form1 : Form
    {
        Jogo jogo;
        public Color Colors { get; set; }
        public Form1(Color Colors)
        {
            this.Colors = Colors;
            InitializeComponent();
            Iniciar();
        }
        public void Iniciar()
        {
            jogo = new Jogo(timer1, lblpontos, panel1, lblrecord, Colors);
            jogo.StartGame();

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                jogo.Direcao2 = e.KeyCode;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            jogo.Tick();
            if (jogo.resp == false)
            {
                this.Close();
            }
        }
    }
}
