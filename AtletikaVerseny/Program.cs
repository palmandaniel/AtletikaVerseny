using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AtletikaVerseny
{
    class Program
    {
        static List<Atleta> atletak = new List<Atleta>();
        static List<string> egyesuletek = new List<string>();
        static void Feladat1()
        {
            Console.WriteLine("1. Feladat: adatok beolvasása...\n");
            StreamReader file = new StreamReader("tavol.csv");
            while (!file.EndOfStream)
            {
                atletak.Add(new Atleta(file.ReadLine()));
            }
            file.Close();
        }

        static void Feladat2()
        {
            Console.WriteLine("2. Feladat: Nevek és ugrások");
            for (int i = 0; i < atletak.Count; i++)
            {
                Console.WriteLine($"\t {atletak[i].ANeve}\t {atletak[i].Ugras}");
            }
        }

        static void Feladat3()
        {
            for (int i = 0; i < atletak.Count; i++)
            {
                if (!egyesuletek.Contains(atletak[i].Egyesulet))
                {
                    egyesuletek.Add(atletak[i].Egyesulet);
                }
            }

            Console.WriteLine("\n3. Feladat: Egyesületek");
            for (int i = 0; i < egyesuletek.Count; i++)
            {
                Console.WriteLine(egyesuletek[i]);
            }
        }

        static void Feladat4()
        {
            Console.WriteLine("\n4. Feladat: Legnagyobb ugrás");
            int legnagyobb = 0;
            for (int i = 0; i < atletak.Count; i++)
            {
                if (legnagyobb<atletak[i].Ugras)
                {
                    legnagyobb = atletak[i].Ugras;
                }
            }

            for (int i = 0; i < atletak.Count; i++)
            {
                if (atletak[i].Ugras == legnagyobb)
                {
                    Console.WriteLine($"{atletak[i].ANeve}: {atletak[i].Ugras} cm");
                }
            }
        }

        static void Feladat5()
        {
            Console.WriteLine();
            int db = 0;
            double atlag = 0;
            double sum = 0;
            for (int i = 0; i < atletak.Count; i++)
            {
                sum += atletak[i].Ugras;
            }

            atlag = sum / atletak.Count;

            for (int i = 0; i < atletak.Count; i++)
            {
                if (atletak[i].Ugras < atlag)
                {
                    db++;
                }
            }

            Console.WriteLine("5. Feladat: Átlag alatt lévő ugrások száma: {0}",db);
        }

        static void Feladat6()
        {
            Console.WriteLine("\n6. Feladat: Adatok fájlba írása...");
            StreamWriter fileba = new StreamWriter("versenyzok.txt");
            for (int i = 0; i < atletak.Count; i++)
            {
                fileba.WriteLine($"{atletak[i].Rajtszam};{atletak[i].ANeve}");
            }
            fileba.Close();
        }
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Console.ReadKey();
        }
    }
}
