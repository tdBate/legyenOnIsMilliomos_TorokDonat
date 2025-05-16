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
                
            }
            else
            {
                Console.WriteLine("Nem nyertél");
            }
        }
    }
}
