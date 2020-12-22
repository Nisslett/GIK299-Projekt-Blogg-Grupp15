using System;
namespace GIK299_Projekt_Blogg
{
    class Program
    {
        private static Blogg OurBlogg;
        static void Main(string[] args)
        {
            Console.ForegroundColor=ConsoleColor.Green;
            Console.Clear();
            OurBlogg= new Blogg();
            while (true)
            {
                Console.WriteLine("Welcome to Nils, Adams and Tores blogg!");
                Console.WriteLine("1. Add an entry to the blogg.");
                Console.WriteLine("2. Print all blogg entries.");
                Console.WriteLine("E. Exit.");
                string menySwitch = Console.ReadLine();
                Console.WriteLine();
                switch (menySwitch)
                {
                    case "1":
                        MakeNewEntry();
                        break;
                    case "2":
                        OurBlogg.ConsolePrintAll();
                        break;
                    case "E":
                        Console.WriteLine("Exitting program!");
                        // ending Program
                        break;
                    default:
                        Console.WriteLine("Invalid input try again!");
                        break;
                }
                Console.ReadLine();
                Console.Beep();
                Console.Clear();
                if (menySwitch == "E")
                {
                    break;
                }
            }

        }

        private static void MakeNewEntry()
        {
            //define entry
            Entry NewEntry= new Entry("The Meaning Of Life","Douglas Adams","42 - Fourthytwo");

            OurBlogg.AddEntry(NewEntry);
        }
    }
}
