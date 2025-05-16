using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (SorKerdesJatszas())
            {
                Kerdes k = new Kerdes();

                int lepes = 0;
                bool marade = true;
                while (marade)
                {
                    k.SorKerdesHuzas(lepes);
                    Console.WriteLine("Jelenlegi egyenleg: "+penzosszeg+" Ft");
                    k.SorKerdesKiiras();

                    if (k.ValaszCheck(Console.ReadLine()))
                    {
                        Console.WriteLine("Helyes válasz!");
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
