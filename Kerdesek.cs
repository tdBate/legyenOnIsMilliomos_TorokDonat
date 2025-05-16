using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdesek
    {
        private List<string[]> feladatok = new List<string[]>();

        public List<string[]> Feladatok { get => feladatok; }

        public void KerdesBeolvas(string path)
        {

            
            string[] lines = File.ReadAllLines(path);
            //string[] adatok = lines[rnd.Next(0, lines.Length)].Split(';');
            foreach (string line in lines)
            {
                string[] adatok = line.Split(';');
                feladatok.Add(adatok);
            }
        }
    }
}
