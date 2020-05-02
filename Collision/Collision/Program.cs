using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 * 
 * 
 * 
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
                Random RG = new Random();
                //wählt eine zufällige Farebe aus
                #region Farbe
                switch (RG.Next(0, 15))
                {
                    case 0:
                        farbe = ConsoleColor.Black;
                        break;
                    case 1:
                        farbe = ConsoleColor.Blue;
                        break;
                    case 2:
                        farbe = ConsoleColor.Cyan;
                        break;
                    case 3:
                        farbe = ConsoleColor.DarkBlue;
                        break;
                    case 4:
                        farbe = ConsoleColor.DarkCyan;
                        break;
                    case 5:
                        farbe = ConsoleColor.DarkGray;
                        break;
                    case 6:
                        farbe = ConsoleColor.DarkGreen;
                        break;
                    case 7:
                        farbe = ConsoleColor.DarkMagenta;
                        break;
                    case 8:
                        farbe = ConsoleColor.DarkRed;
                        break;
                    case 9:
                        farbe = ConsoleColor.DarkYellow;
                        break;
                    case 10:
                        farbe = ConsoleColor.Gray;
                        break;
                    case 11:
                        farbe = ConsoleColor.Green;
                        break;
                    case 12:
                        farbe = ConsoleColor.Magenta;
                        break;
                    case 13:
                        farbe = ConsoleColor.Red;
                        break;
                    case 14:
                        farbe = ConsoleColor.White;
                        break;
                    case 15:
                        farbe = ConsoleColor.Yellow;
                        break;
                }
                #endregion
                //Wählt eine zufällige, freie Possition aus
                // Achtung, wenn mehr als 2500 Einer erzeugt werden entsteht eine Endlosschleife
                do
                {
                    posx = RG.Next(0, seite);
                    posy = RG.Next(0, seite);
                } while (feld[posx, posy] == 1);
                feld[posx, posy] = 1;

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
            }

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = seite*2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl=ZG.Next(1,6);
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
