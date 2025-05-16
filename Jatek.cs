using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Jatek
    {
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
                    k.SorKerdesKiiras();

                    if (k.ValaszCheck(Console.ReadLine()))
                    {
                        Console.WriteLine("Helyes válasz!");
                    }
                    else
                    {
                        Console.WriteLine("Helytelen válasz!");
                        marade = false;
                    }

                    //Console.WriteLine(k.VegIndex +" "+ k.KezdoIndex);

                    if (k.VegIndex-k.KezdoIndex == lepes)
                    {
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
