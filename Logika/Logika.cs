using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Logika
{
    public class Logika
    {
        Thread gracz1;
        Thread grazc2;
        Szachownica szachownica;
        Szachownica szachownicaGracza1;
        Szachownica szachownicaGracza2;
        public void Start()
        {
            gracz1 = new Thread(szachownicaGracza1.Start());
            szachownica = new Szachownica();
        }
    }
}
