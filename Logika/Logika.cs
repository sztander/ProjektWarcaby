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
        //0 to nie ma pionka , 1 bialy, 2 czarny
        bool statusGry; // jak jest ON to jest true
        Thread graczJedenThread;
        Thread graczDwaThread;
        Gracz jeden;
        Gracz dwa;
        Szachownica szachownica;
        static void Main(string[] args)
        {
            Console.WriteLine("jazda");
        }
        public void Start()
        {
            jeden = new Gracz("Bialy");
            dwa = new Gracz("Czarny");
            szachownica = new Szachownica();
            graczJedenThread = new Thread(PierwszyGraczTura);
            graczDwaThread = new Thread(DrugGraczTura);
            graczJedenThread.Start();
            graczDwaThread.Start();
            statusGry = true;
            GraJuzLeci();
        }
        public void GraJuzLeci()
        {
            if (jeden.tura == true)
            {
                PierwszyGraczTura();
                szachownica.tabela = jeden.tabela;
            }
            if (dwa.tura == true)
            {
                DrugGraczTura();
                szachownica.tabela = dwa.tabela;
            }
            if (SprawdzanieCzyKoniec() == true)
            {
                statusGry = false;
                // przekierowanie do metody co komunikat wyswietli, jakiegos boxa czy cos
            }
        }
        public void PierwszyGraczTura()
        {
            if (jeden.tura == false)
            {
                return;
            }

            //tutaj jakos trzeba pobrac dane z frontenda i zobaczyc jakie miejsce zostalo zaznaczone do przesuniecia, albo odrazu mozna tutaj cala tabele przeslac;
            int[,] tablicaPoZmianach = new int[8, 8] { { 0, 1, 0, 1, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1, 0, 1, 0 }, { 0, 0, 0, 1, 0, 1, 0, 1 }, { 1, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 2, 0, 2, 0, 2, 0, 2, 0 }, { 0, 2, 0, 2, 0, 2, 0, 2 }, { 2, 0, 2, 0, 2, 0, 2, 0 } };
            ///
            jeden.tabela = tablicaPoZmianach;
            Thread.Sleep(100);
        }
        public void DrugGraczTura()
        {
            if (dwa.tura == false)
            {
                return;
            }
            //tutaj jakos trzeba pobrac dane z frontenda i zobaczyc jakie miejsce zostalo zaznaczone do przesuniecia, albo odrazu mozna tutaj cala tabele przeslac;
            int[,] tablicaPoZmianach = new int[8, 8] { { 0, 1, 0, 1, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1, 0, 1, 0 }, { 0, 0, 0, 1, 0, 1, 0, 1 }, { 1, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 2, 0, 2, 0, 2, 0, 2, 0 }, { 0, 2, 0, 2, 0, 2, 0, 2 }, { 2, 0, 2, 0, 2, 0, 2, 0 } };
            ///
            jeden.tabela = tablicaPoZmianach;
            Thread.Sleep(100);
        }
        public bool SprawdzanieCzyKoniec()
        {
            bool wynikMetody = false;
            // jak jest w tych intach wiecej niz 1 to znaczy ze jest na szachownicy wiecej niz jeden pionek tego koloru
            int checkBiale = 0;
            int checkCzarne = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8 ; j++)
                {
                    if (szachownica.tabela[i,j] == 1)
                    {
                        checkBiale++;
                    }
                    if (szachownica.tabela[i, j] == 2)
                    {
                        checkCzarne++;
                    }
                }
            }
            if (checkBiale == 0)
            {
                if (jeden.kolor == "Czarny")
                {
                    jeden.winner = true;
                }
                else
                {
                    dwa.winner = true;
                }
                wynikMetody = true;
            }
            if (checkCzarne == 0)
            {
                if (jeden.kolor == "Bialy")
                {
                    jeden.winner = true;
                }
                else
                {
                    dwa.winner = true;
                }
                wynikMetody = true;
            }
            return wynikMetody;
        }
    }
}
