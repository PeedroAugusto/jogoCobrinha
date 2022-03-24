using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoDaCobrinha
{
   public class Cobra
    {
        public int c { get; set; }// tamanho da cobra
        public Point[] Location { get; set; }
        public Cobra()
        {
            Location = new Point[28 * 28];
            Resetar();
        }

        public void Resetar()
        {
            c = 5;
            for (int i = 0; i < Location.Length; i++)
            {
                foreach (var item in Location)
                {
                    Location[i].X = 0;
                    Location[i].Y = 0;
                }
            }
            for (int i = 0; i < c; i++)
            {
                Location[i].X = 12;
                Location[i].Y = 12;
            }
        }
        public void Corpo()
        {
            for (int i = c - 1; i > 0; i--)
            {
                Location[i] = Location[i - 1];
            }
        }// faz o corpo ficar junto
        public void Comeu()
        {
            c++;
        }// aumenta qnd ela come
        public void Up()//Subir
        {
            Corpo();
            Location[0].Y--;
        }
        public void Donw()
        {
            Corpo();
            Location[0].Y++;
        }
        public void left()
        {
            Corpo();
            Location[0].X--;
        }
        public void Right()
        {
            Corpo();
            Location[0].X++;
        }
    }
}
