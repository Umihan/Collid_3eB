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
        const int seite = 10;
        static int[,] feld = new int[seite, seite];

        class einer
        {   
            
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            Random RG = new Random();
            
            // Konstruktor
            public einer()
            {              
                //wählt eine zufällige Farebe aus
                farbe = (ConsoleColor)RG.Next(0, 15);
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
            einer[] meineEiner = new einer[100];
            for (int i = 0; i < 100; i++)
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
