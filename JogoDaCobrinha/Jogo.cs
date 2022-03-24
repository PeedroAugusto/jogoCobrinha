using System.Drawing;
using System.Windows.Forms;
namespace JogoDaCobrinha
{
    class Jogo
    {
        private bool gamerOver;
        public bool resp = true;
        private int jogada = 0;
        private int y;

        public Keys Direcao1 { get; set; }// direção atual
        public Keys Direcao2 { get; set; }// direção antiga

        private Timer timer { get; set; }
        private Label label { get; set; }
        private Panel tela { get; set; }//painel do form
        private int pontos { get; set; }
        public Color corcobra { get; set; }
        public Label label2 { get; set; }
        private Comida comida { get; set; }//comida
        private Cobra cobra { get; set; }// cobra
        public int record { get; set; }
        private Bitmap offbitmap { get; set; }// negocio de desenha que não entendi
        private Graphics graphicsbit { get; set; }// negocio de desenha que não entendi
        private Graphics screegraphics2 { get; set; }// negocio de desenha que não entendi

        public Jogo(Timer timer, Label label, Panel panel, Label label2, Color cor)
        {
            this.timer = timer;
            this.label = label;
            this.label2 = label2;
            this.tela = panel;
            corcobra = cor;
            this.offbitmap = new Bitmap(428, 428);
            comida = new Comida();
            cobra = new Cobra();
            Direcao1 = Keys.Left;
            Direcao2 = Keys.Left;
        }
        public Jogo()
        {

        }
        public void StartGame()
        {
            cobra.Resetar();
            comida.CriarFood();
            Direcao1 = Keys.Left;
            graphicsbit = Graphics.FromImage(offbitmap);
            screegraphics2 = tela.CreateGraphics();
            timer.Enabled = true;
        }
        public void Tick()
        {
            if ((Direcao2 == Keys.Left) && (Direcao1 != Keys.Right)
                || (Direcao2 == Keys.Right) && (Direcao1 != Keys.Left)
                || (Direcao2 == Keys.Down) && (Direcao1 != Keys.Up)
                || (Direcao2 == Keys.Up) && (Direcao1 != Keys.Down))
            {
                Direcao1 = Direcao2;
            } // se estiver (direita) não vai para (esquerda)...
            switch (Direcao1)
            {
                case Keys.Left:
                    cobra.left();
                    break;
                case Keys.Right:
                    cobra.Right();
                    break;
                case Keys.Up:
                    cobra.Up();
                    break;
                case Keys.Down:
                    cobra.Donw();
                    break;

            }// mexe a cobra

            graphicsbit.Clear(System.Drawing.Color.White);// limpa um tamnho qnd ela se mexe
            graphicsbit.DrawImage(Properties.Resources.maca, (comida.Location.X * 15), (comida.Location.Y * 15), 15, 15);// faz comida
            gamerOver = false;

            for (int i = 0; i < cobra.c; i++)
            {
                if (i == 0)
                {
                    if (corcobra.Name == "Blue")
                    {
                        graphicsbit.FillEllipse(new SolidBrush(Color.DarkBlue), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);// desenha a cabeça da cobra
                    }
                    if (corcobra.Name == "Green")
                    {
                        graphicsbit.FillEllipse(new SolidBrush(Color.DarkGreen), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);// desenha a cabeça da cobra
                    }
                    if (corcobra.Name == "Black")
                    {
                        graphicsbit.FillEllipse(new SolidBrush(Color.Gray), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);// desenha a cabeça da cobra
                    }
                }
                else
                {
                    if (corcobra.Name == "Blue")
                    {
                        graphicsbit.FillEllipse(new SolidBrush(Color.Blue), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);// desenha o corpo da cobra
                    }
                    if (corcobra.Name == "Green")
                    {
                        graphicsbit.FillEllipse(new SolidBrush(Color.Green), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);// desenha o corpo da cobra
                    }
                    if (corcobra.Name == "Black")
                    {
                        graphicsbit.FillEllipse(new SolidBrush(Color.Black), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);// desenha o corpo da cobra
                    }
                }
                if ((cobra.Location[i] == cobra.Location[0]) && (i > 0))
                {
                    gamerOver = true;
                }
            }// desemha a cobra
            verificar();
            screegraphics2.DrawImage(offbitmap, 0, 0);
            if (gamerOver)
            {
                GameOver();
                gamerOver = false;
            }
        } // timer
        private void verificar()// verifica o gameOver
        {
            if (cobra.Location[0] == comida.Location)
            {
                cobra.Comeu();
                comida.CriarFood();
                pontos += 10;
                label.Text = $"Pontos: {pontos}";

            }
            y = 1;
            for (int i = 0; i < cobra.c; i++)
            {
                if (cobra.Location[0] == cobra.Location[y])
                {
                    gamerOver = true;
                }
                y++;

            }
            if (cobra.Location[0].Y > 27 || cobra.Location[0].Y < 0 || cobra.Location[0].X > 27 || cobra.Location[0].X < 0)
            {
                 gamerOver = true;
            }
        }
        public void GameOver()// reinicar o jogo ou fechar
        {
            timer.Stop();
            graphicsbit.Clear(System.Drawing.Color.White);// limpa um tamnho qnd ela se mexe
            y = 1;
            graphicsbit.Dispose();
            graphicsbit.Dispose();
            label.Text = $"Pontos: {pontos}";
            var result = MessageBox.Show("Deseja jogar novamente?", "Atenção", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                if (jogada == 0)
                {
                    record = pontos;
                    label2.Text = $"Record: {record}";
                    jogada++;
                }
                if (pontos > record)
                {
                    record = pontos;
                    label2.Text = $"Record: {record}";
                }
                pontos = 0;
                label.Text = $"Pontos: {pontos}";
                StartGame();
            }
            else
            {
                resp = false;
            }
        }
    }
}
