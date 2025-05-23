using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace legyenOnIsMilliomos
{
    internal class SorKerdes 
    {
        protected Random rnd = new Random();

        protected string kerdesSzoveg;
        protected string[] valaszok = new string[4];
        protected string helyesValasz;
        protected string kategoria;


        public void SorKerdesKiiras(int segitsegKod = 0) //1: közönség 2: felező 3: telefonos
        {
            //Console.WriteLine("TÖRÖLNI!!!!!! - "+helyesValasz); //majd a kész játéknál
            Console.WriteLine("Kategória: " + kategoria);
            Console.WriteLine(kerdesSzoveg);

            char[] betuk = { 'A', 'B', 'C', 'D' };

            if (segitsegKod == 0)
            {
                for (int i = 0; i < valaszok.Length; i++)
                {
                    Console.WriteLine("\t" + betuk[i] + ": " + valaszok[i]);
                }
            }
            else if (segitsegKod == 1)
            {
				int[] szazalekok = new int[valaszok.Length];
				int osszertek = 0;
				for (int i = 0; i < valaszok.Length - 1; i++)
				{
					int osszeg = rnd.Next(1, 100 - osszertek);
					osszertek += osszeg;
					szazalekok[i] = osszeg;
				}
				szazalekok[szazalekok.Length - 1] = 100 - osszertek;
				
                int maxSzam = szazalekok.Max();
				(szazalekok[Array.IndexOf(szazalekok, maxSzam)], szazalekok[Array.IndexOf(betuk, Convert.ToChar(helyesValasz))]) = (szazalekok[Array.IndexOf(betuk, Convert.ToChar(helyesValasz))], szazalekok[Array.IndexOf(szazalekok, maxSzam)]);

				for (int i = 0; i < valaszok.Length; i++)
				{
					Console.Write("\t" + betuk[i] + ": " + valaszok[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" szavazás eredmény: " + szazalekok[i] + "%");
                    Console.ResetColor();
				}
			}
            else if (segitsegKod==2)
            {
                int helyesIndex = Array.IndexOf(betuk, Convert.ToChar(helyesValasz));

                bool marade = true;
                int masikRandomSzam =0;
                while (marade)
                {
                    masikRandomSzam = rnd.Next(0, valaszok.Length);
                    if (helyesIndex != masikRandomSzam)
					{
						marade = false;
					}
                }

				for (int i = 0; i < valaszok.Length; i++)
				{
                    Console.ResetColor();
                    if (!(helyesIndex == i || masikRandomSzam == i)) { Console.ForegroundColor = ConsoleColor.Black; }
					Console.WriteLine("\t" + betuk[i] + ": " + valaszok[i]);
				}
			}
            else if (segitsegKod == 3)
			{
                for (int i = 0; i < valaszok.Length; i++)
				{
					Console.WriteLine("\t" + betuk[i] + ": " + valaszok[i]);
				}
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Csapbetét Csabi szerint a "+helyesValasz+" opció a helyes");
				Console.ResetColor();
			}
        }

        public virtual bool ValaszCheck(string valasz)
        {
            return helyesValasz.Equals(valasz.ToUpper());
        }
        public virtual void SorKerdesHuzas()
        {
            Kerdesek k2 = new Kerdesek();
            string path = @"../../sorkerdes.txt";

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
