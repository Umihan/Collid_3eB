using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 * Maximilian
 * Schuster
 * 4 BEL
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
     class Program
    {
        const int seite = 25;
        static int[,] feld = new int[seite, seite];
        static Random RG_Konstruktor = new Random();

        class einer
        {   
            
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            
            // Konstruktor
            public einer()
            {
                
                //wählt eine zufällige Farebe aus
                farbe = (ConsoleColor)RG_Konstruktor.Next(0, 16);
                //Wählt eine zufällige, freie Possition aus
                // Achtung, wenn mehr als 2500 Einer erzeugt werden entsteht eine Endlosschleife
                do
                {
                    posx = RG_Konstruktor.Next(0, seite);
                    posy = RG_Konstruktor.Next(0, seite);
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
                Random rnd = new Random();

                int richtung = rnd.Next(1, 4);

                hide();

                feld[posx, posy] = 0;



                switch (richtung)
                {
                    case 1:

                        posx++;
                        break;

                    case 2:

                        posy++;
                        break;

                    case 3:

                        posx--;
                        break;

                    case 4:

                        posy--;
                        break;
                }
                    


                    if (posx == -1)
                    {
                        posx = 49;
                    }

                    if (posx == 50)
                    {
                        posx = 0;
                    }

                    if (posy == -1)
                    {
                        posy = 49;
                    }

                    if (posy == 50)
                    {
                        posy = 0;
                    }



                    if (feld[posx, posy] == 0)
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
         // d) Matthias Schrötter
        // Lest die config.ini datei aus und gibt true (Anzahl > 0) oder false (Anzahl > 0) aus.
        static bool LoadConfig(ref int Anzahl)
        {
            StreamReader sr = new StreamReader(@"config.ini");
            while (sr.Peek() != -1)
            {
                Anzahl = Convert.ToInt32(sr.ReadLine());
            }

            sr.Close();

            if (Anzahl > 0)

                return true;
            else
                return false;
        }

        // Erstellt die Datei Config.ini und schaut ob die Datei Config.ini erstell wurde oder nicht. Gibt die parameter true oder false zurück.
        static bool SaveConfig(int Anzahl)
        {
            StreamWriter sw = new StreamWriter(@"config.ini");
            sw.WriteLine(Anzahl);
            sw.Flush();
            sw.Close();

            bool fileExist = File.Exists(@"config.ini");
            if (fileExist)

                return true;
            else
                return false;
        }
    }
}
