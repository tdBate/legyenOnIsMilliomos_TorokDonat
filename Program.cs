using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*SorKerdes sorKerdes1 = new SorKerdes();
            sorKerdes1.SorKerdesHuzas();
            sorKerdes1.SorKerdesKiiras();
            Console.Write("Váalasz: ");
            string valasz = Console.ReadLine();
            Console.WriteLine(sorKerdes1.ValaszCheck(valasz));
            Console.ReadKey();*/

            Kerdes kerdes1 = new Kerdes();
            kerdes1.SorKerdesHuzas();
            kerdes1.SorKerdesKiiras();
            Console.Write("Váalasz: ");
            string valasz2 = Console.ReadLine();
            Console.WriteLine(kerdes1.ValaszCheck(valasz2));
            Console.ReadKey();
        }
    }
}
