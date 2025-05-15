using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdes : SorKerdes
    {
        public override void SorKerdesHuzas()
        {
            string path = @".\kerdes.txt";
            string[] lines = File.ReadAllLines(path);
            string[] adatok = lines[rnd.Next(0, lines.Length)].Split(';');

            kerdesSzoveg = adatok[1];
            valaszok[0] = adatok[2];
            valaszok[1] = adatok[3];
            valaszok[2] = adatok[4];
            valaszok[3] = adatok[5];
            helyesValasz = adatok[6];
            kategoria = adatok[7];
        }

        public override bool ValaszCheck(string valasz)
        {
            return false;
        }
    }
}
