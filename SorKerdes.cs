using System;
using System.Collections.Generic;
using System.IO;

namespace legyenOnIsMilliomos
{
    internal class SorKerdes 
    {
        protected Random rnd = new Random();

        protected string kerdesSzoveg;
        protected string[] valaszok = new string[4];
        protected string helyesValasz;
        protected string kategoria;


        public void SorKerdesKiiras()
        {
            Console.WriteLine("Kategória: " + kategoria);
            Console.WriteLine(kerdesSzoveg);
            Console.WriteLine("\tA: " + valaszok[0]);
            Console.WriteLine("\tB: " + valaszok[1]);
            Console.WriteLine("\tC: " + valaszok[2]);
            Console.WriteLine("\tD: " + valaszok[3]);
        }

        public virtual bool ValaszCheck(string valasz)
        {
            return helyesValasz.Equals(valasz.ToUpper());
        }
        public virtual void SorKerdesHuzas()
        {
            Kerdesek k2 = new Kerdesek();
            string path = @".\sorkerdes.txt";

            k2.KerdesBeolvas(path);
            List<string[]> lines = k2.Feladatok;

            string[] adatok = lines[rnd.Next(0, lines.Count/6)];

            Console.WriteLine(adatok[3].GetType());

            kerdesSzoveg = adatok[0];
            valaszok[0] = adatok[1];
            valaszok[1] = adatok[2];
            valaszok[2] = adatok[3]; 
            valaszok[3] = adatok[4];
            helyesValasz = adatok[5];
            kategoria = adatok[6];
        }      
    }
}
