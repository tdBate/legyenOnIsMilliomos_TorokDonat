using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace legyenOnIsMilliomos
{
    internal class Kerdes : SorKerdes
    {
        private int kezdoIndex = -1;
        private int vegIndex = -1;

        public int KezdoIndex { get => kezdoIndex; set => kezdoIndex = value; }
        public int VegIndex { get => vegIndex; set => vegIndex = value; }


        public void SorKerdesHuzas(int iteration = 0)
        {
            

        string path = @"../../kerdes.txt";

        Kerdesek k1 = new Kerdesek();
        k1.KerdesBeolvas(path);

            List<string[]> lines = k1.Feladatok;

            if (kezdoIndex == -1)
            {
                for (int i = rnd.Next(0, lines.Count - 4); i < lines.Count; i++)
                {
                    if (lines[i][0].Equals("1") && kezdoIndex == -1)
                    {
                        kezdoIndex = i;
                    }
                    else if (lines[i][0].Equals("1") && vegIndex == -1)
                    {
                        vegIndex = i - 1;
                    }
                }
            }

            //Console.WriteLine(lines[kezdoIndex][0]);
            //Console.WriteLine(lines[vegIndex][0]);
            string[] adatok = lines[kezdoIndex+iteration];

            kerdesSzoveg = adatok[1];
            valaszok[0] = adatok[2];
            valaszok[1] = adatok[3];
            valaszok[2] = adatok[4];
            valaszok[3] = adatok[5];
            helyesValasz = adatok[6];
            kategoria = adatok[7];
        }

   }
}
