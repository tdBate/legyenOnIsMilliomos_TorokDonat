using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Jatek
    {
        private int penzosszeg = 0;

        static bool SorKerdesJatszas()
        {
            SorKerdes sk = new SorKerdes();
            sk.SorKerdesHuzas();
            sk.SorKerdesKiiras();
            return sk.ValaszCheck(Console.ReadLine());
        }


        public void JatekIndit()
        {
            Console.WriteLine("Üdvözlöm a Legyen Ön is milliomos játékban!");
            Thread.Sleep(1000);
            Console.WriteLine("Itt az idő megválaszolni a sorkérdést!");
            Thread.Sleep(1000);

            if (SorKerdesJatszas())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A válasza helyes volt!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine("Tovább mehet a rendes kérdésekre ahol már pénzt is nyerhet!");
                Thread.Sleep(2500);

                Kerdes k = new Kerdes();

                int lepes = 0;
                bool marade = true;
                while (marade)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine((lepes+1)+". kör következik");
                    Console.ResetColor ();
                    Thread.Sleep(1000);
                    
                    k.SorKerdesHuzas(lepes);
                    Console.WriteLine("Jelenlegi egyenleg: "+penzosszeg+" Ft");
                    k.SorKerdesKiiras();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (k.ValaszCheck(Console.ReadLine()))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("A válasza helyes volt!");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                        penzosszeg *= 2;
                        if (penzosszeg == 0)
                        {
                            penzosszeg = 10000;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Helytelen válasz!");
                        marade = false;
                    }

                    //Console.WriteLine(k.VegIndex +" "+ k.KezdoIndex);

                    if (k.VegIndex-k.KezdoIndex == lepes)
                    {
                        Console.WriteLine("Nyert "+penzosszeg+" Forintot!!");
                        marade = false;
                    }

                    lepes++;
                }
            }
            else
            {
                Console.WriteLine("Nem nyertél");
            }
            
        }
    }
}
