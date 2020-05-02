using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 * Thomas
 * Weithaler
 * 4 BEL
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
    class Program
    {
        const int seite = 50;
        static int[,] feld = new int[seite, seite];

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            // Konstruktor
            public einer()
            {
            }
            //Private Methoden
            void show()
            {
            }
            void hide()
            {
            }
            void collide()
            {
            }
            //Öffentliche Methoden
            public void Move()
            {
                Random Zufallszahl = new Random();
                int Richtung = Zufallszahl.Next(1, 4);

                switch (Richtung)
                {
                    case 1: //in Richtung +x
                        hide();     //entfernt das Objekt an der alten Position
                        posx++;     //setzt das Objekt um eine einheit nach rehts;
                        show();
                        break;

                    case 2: //in Richtung +y
                        hide();     //entfernt das Objakt an der alen Position
                        posy++;     //setzt das Objekt um eine Einheit nach oben
                        show();
                        break;

                    case 3: //in Richtung -x
                        hide();
                        posx--;
                        show();
                        break;

                    case 4: //in Richtung y-
                        hide();
                        posy--;
                        show();
                        break;
                }

            }

            static void Main(string[] args)
            {
                Console.WindowWidth = seite * 2;
                Console.WindowHeight = seite;
                Console.Clear();
                Random ZG = new Random();
                int Anzahl = ZG.Next(1, 6);
                einer[] meineEiner = new einer[Anzahl];
                for (int i = 0; i < Anzahl; i++)
                {
                    meineEiner[i] = new einer();
                }
                Console.CursorVisible = false;
                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < Anzahl; j++)
                    {
                        meineEiner[j].Move();
                    }
                    System.Threading.Thread.Sleep(10);

                }
            }
        }
    }
}
