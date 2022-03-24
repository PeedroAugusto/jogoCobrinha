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
    public partial class Login : Form
    {
        public Color Cor { get; set; }
        public Login()
        {
            InitializeComponent();
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            if (a.Checked)
            {
                Cor = Color.Blue;
            }
            else if (p.Checked)
            {
                Cor = Color.Black;
            }
            else
            {
                Cor = Color.Green;
            }
            Form1 form = new Form1(Cor);
            form.Show();
        }
    }
}
