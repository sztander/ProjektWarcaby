using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    class Gracz
    {
        public int[,] tabela;
        public bool tura;
        public string nazwaGracza;
        public string kolor;
        public bool winner;
        public Gracz(string kolorr)
        {
            tabela = new int[8, 8] { { 0, 1, 0, 1, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1, 0, 1, 0 }, { 0, 1, 0, 1, 0, 1, 0, 1 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 2, 0, 2, 0, 2, 0, 2, 0 }, { 0, 2, 0, 2, 0, 2, 0, 2 }, { 2, 0, 2, 0, 2, 0, 2, 0 } };
            if (kolorr == "Czarny")
            {
                kolor = kolorr;
                tura = true;
            }
            else
            {
                kolor = "Bialy";
                tura = false;
            }
        }
    }
}
