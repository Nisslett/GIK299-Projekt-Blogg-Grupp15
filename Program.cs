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
                Console.WriteLine("3. Sort.");
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
                        Console.ReadLine();
                        break;
                    case "3":
                        SortMenu();
                        break;
                    case "E":
                        Console.WriteLine("Exitting program!");
                        // ending Program
                        break;
                    default:
                        Console.WriteLine("Invalid input try again!");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
                if (menySwitch == "E")
                {
                    break;
                }
            }

        }

        private static int InputInteger()
        {   
            int input;
            while(!int.TryParse(Console.ReadLine(),out input))
            {
                Console.WriteLine("Not a valid integer try again!");
            }
            return input;
        }

        private static string InputString()
        {   
            string input=null;
            do{
                if(input!=null)
                {
                    Console.WriteLine("Input can't be empty!");
                }
                input=Console.ReadLine();
            }while(string.IsNullOrEmpty(input));
            return input;
        }

        private static void MakeNewEntry()
        {
            Console.WriteLine("Input the blogg entry's author name:");
            string author=InputString();
            Console.WriteLine("Input the blogg entry's title:");
            string title=InputString();
            Console.WriteLine("Input the blogg text content:");
            string text=InputString();
            OurBlogg.AddEntry(new Entry(title,author,text));
        }

        private static void SortMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Sort from newest to oldest");
            Console.WriteLine("2. Sort from oldest to newest");
            int choice = InputInteger();
            
            if(choice == 1)
            {
                OurBlogg.SortDateTime(true);
            }
            else if(choice == 2)
            {
                OurBlogg.SortDateTime(false);
            }
        }
    }
}
