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
                // Objecte, welche nicht mehr gebraucht werden werden entfernt.

                feld[posx, posy] = 0;                      // Das Feld an posx,posy wird hier wieder freigegeben.
                Console.SetCursorPosition(posx, posy);    // Der Cursor wird auf die gewünste Position gesetzt.
                Console.Write(" ");                      // Ein Leerzeichen wird ausgeschrieben um das vorherige zeichen zu überschreiben.

            }
            void collide()
            {
            }
            //Öffentliche Methoden
            public void Move()
            {
                Random RG_Move = new Random(System.DateTime.UtcNow.Millisecond);
                int Richtung = RG_Move.Next(0, 5);
                
                hide();     //entfernt das Objekt an der alten Position
                feld[posx, posy] = 0;

                switch (Richtung)
                {
                    case 1: //in Richtung +x
                        posx++;     //setzt das Objekt um eine einheit nach rehts;
                        break;

                    case 2: //in Richtung +y
                        posy++;     //setzt das Objekt um eine Einheit nach oben
                        break;

                    case 3: //in Richtung -x
                        posx--;     //Objekt nach links
                        break;

                    case 4: //in Richtung y-
                        posy--;     //Objekt nach unten
                        break;
                }

                //Dieser Teil ueberprueft ob sich das Objekt ueber den Rand hinaus bewegt hat,
                //und setzt ggf. auf den Anfang der gegenueberliegenden Seite.
                if (posx == -1)
                    posx = 49;

                if (posx == 50)
                    posx = 0;

                if (posy == -1)
                    posy = 49;

                if (posy == 50)
                    posy = 0;

                if (feld[posx, posy] == 0) //schaut ob auf der neuen Position bereits ein Objekt ist
                {
                    show();
                    feld[posx, posy] = 1;
                }
                else
                {
                    collide();
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
