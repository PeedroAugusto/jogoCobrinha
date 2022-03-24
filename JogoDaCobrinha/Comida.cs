using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaCobrinha
{
    class Comida
    {
        public Point Location { get; set; }

        public void CriarFood()
        {
            Random rnd = new Random();
            Location = new Point(rnd.Next(0, 27), rnd.Next(0, 27));
        }
    }
}
