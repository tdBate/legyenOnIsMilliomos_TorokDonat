using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Jatek
    {
        private int penzosszeg = 0;
        private bool[] segitsegVoltMar = {false,false,false };

        
        static bool SorKerdesJatszas()
        {
            SorKerdes sk = new SorKerdes();
            sk.SorKerdesHuzas();
            sk.SorKerdesKiiras();
            Console.ForegroundColor = ConsoleColor.Cyan;
            return sk.ValaszCheck(Console.ReadLine());
            
        }


        public void JatekIndit()
        {
            int penznyeremeny = 10000;
            int garantaltNyeremeny = 0;

            Console.WriteLine("Üdvözlöm a Legyen Ön is milliomos játékban!");
            Thread.Sleep(1000);
            Console.WriteLine("Itt az idő megválaszolni a sorkérdést!");
            Thread.Sleep(1000);

            if (SorKerdesJatszas())
            {
                Console.ResetColor();
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
                    if (lepes==4||lepes==9) garantaltNyeremeny = penzosszeg;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine((lepes+1)+". kör következik");
                    Console.ResetColor ();
                    Thread.Sleep(1000);
                    
                    k.SorKerdesHuzas(lepes);
                    Console.WriteLine("Jelenlegi egyenleg: "+penzosszeg+" Ft");
                    Console.WriteLine("Ez a kérdés "+penznyeremeny+" Ft-ot ér");

                    string[] segitsegek = { "1-szavazás", "2-felezés", "3-telefonos segítség" };
                    
                    for (int i = 0; i < segitsegVoltMar.Length; i++)
                    {
                        if (segitsegVoltMar[i]==false)
						{
							Console.Write(segitsegek[i] + " ");
						}
                    }
					Console.WriteLine();


					k.SorKerdesKiiras();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string valasz = Console.ReadLine();
                    Console.ResetColor();

                    if (int.TryParse(valasz,out int szam)) 
                    {
                        if (segitsegVoltMar[szam - 1] == false)
                        {
                            Console.Clear();
							Console.ForegroundColor = ConsoleColor.Magenta;
							Console.WriteLine((lepes + 1) + ". kör következik");
							Console.ResetColor();


							Console.WriteLine("Jelenlegi egyenleg: " + penzosszeg + " Ft");
							Console.WriteLine("Ez a kérdés " + penznyeremeny + " Ft-ot ér");

							k.SorKerdesKiiras(szam);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            valasz = Console.ReadLine();
                            Console.ResetColor();

                            segitsegVoltMar[szam - 1] = true;
                        }
					}

                    if (k.ValaszCheck(valasz))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("A válasza helyes volt!");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();

                        if (penzosszeg == 0)
                        {
                            penzosszeg = penznyeremeny;
                        }
                        else
                        {
                            penzosszeg += penznyeremeny;
                            penznyeremeny = penzosszeg;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Helytelen válasz!");
                        if (garantaltNyeremeny != 0)
                        {
							Console.WriteLine("Nyert " + garantaltNyeremeny + " Forintot!!");
						}
                        marade = false;
                    }

                    //Console.WriteLine(k.VegIndex +" "+ k.KezdoIndex);

                    if (k.VegIndex-k.KezdoIndex == lepes)
                    {
                        garantaltNyeremeny = penzosszeg;
                        Console.WriteLine("Nyert "+garantaltNyeremeny+" Forintot!!");
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
