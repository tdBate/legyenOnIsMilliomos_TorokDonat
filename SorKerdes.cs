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
            Console.WriteLine("TÖRÖLNI!!!!!! - "+helyesValasz); //majd a kész játéknál
            Console.WriteLine("Kategória: " + kategoria);
            Console.WriteLine(kerdesSzoveg);

            char[] betuk = { 'A', 'B', 'C', 'D' };
            for (int i = 0; i < valaszok.Length; i++)
            {
                Console.WriteLine("\t" + betuk[i]+": " + valaszok[i]);
            }
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
