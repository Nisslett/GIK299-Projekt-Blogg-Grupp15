using System;
using System.Collections.Generic;
namespace GIK299_Projekt_Blogg
{
    class Program
    {
        private static Blogg OurBlogg;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            OurBlogg = new Blogg();
            OurBlogg.LoadFromFile();
            while (true)
            {
                Console.WriteLine("Welcome to Nils, Adams and Tores blogg!");
                Console.WriteLine("1. Add an entry to the blogg.");
                Console.WriteLine("2. Print all blogg entries.");
                Console.WriteLine("3. Sort.");
                Console.WriteLine("4. Seach in the blogg");
                Console.WriteLine("E. Exit.");
                string menySwitch = Console.ReadLine().ToUpper();
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
                    case "4":
                        SearchBlogg();
                        Console.ReadLine();
                        break;
                    case "E":
                        Console.WriteLine("Exitting program!");
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
            OurBlogg.SaveToFile();
        }


        private static string InputString()
        {
            string input = null;
            do
            {
                if (input != null)
                {
                    Console.WriteLine("Input can't be empty!");
                }
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        private static void MakeNewEntry()
        {
            Console.WriteLine("Input the blogg entry's author name:");
            string author = InputString();
            Console.WriteLine("Input the blogg entry's title:");
            string title = InputString();
            Console.WriteLine("Input the blogg text content:");
            int emptyCount = 0;
            string text = "";
            string temporary_str = "";
            while (emptyCount < 2)
            {
                temporary_str = Console.ReadLine();
                if (String.IsNullOrEmpty(temporary_str))
                {
                    emptyCount++;
                }
                else
                {
                    emptyCount = 0;
                    if (!String.IsNullOrEmpty(text))
                    {
                        text = text + "\n";
                    }
                    text = text + temporary_str;
                }
            }
            OurBlogg.AddEntry(new Entry(title, author, text));
        }


        private static void SortMenu()
        {
            string choice;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Sort from newest to oldest");
                Console.WriteLine("2. Sort from oldest to newest");
                Console.WriteLine("3. Return to menu.");
                choice = InputString();
                switch (choice)
                {
                    case "1":
                        OurBlogg.SortDateTime(true);
                        break;
                    case "2":
                        OurBlogg.SortDateTime(false);
                        break;
                    case "3":
                        Console.WriteLine("Returning to menu");
                        break;
                    default:
                        Console.WriteLine("Invalid choice try again!");
                        Console.ReadLine();
                        break;
                }
                if (choice == "3")
                {
                    break;
                }
            }
        }

        private static void SearchBlogg()
        {
            string choice;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Search by title.");
                Console.WriteLine("2. Search by author.");
                Console.WriteLine("3. Return to menu.");
                choice = InputString();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Type in the title you are searching for:");
                        List<Entry> foundTitle = OurBlogg.SearchTitle(InputString());
                        if (foundTitle.Count == 0)
                        {
                            Console.WriteLine("No Entry found in the search!");
                        }
                        else
                        {
                            for (int i = 0; i < foundTitle.Count; i++)
                            {
                                foundTitle[i].ConsolePrint();
                            }
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Type in the author you are searching for:");
                        List<Entry> foundAuthor = OurBlogg.SearchAuthor(InputString());
                        if (foundAuthor.Count == 0)
                        {
                            Console.WriteLine("No Entry found in the search!");
                        }
                        else
                        {
                            for (int i = 0; i < foundAuthor.Count; i++)
                            {
                                foundAuthor[i].ConsolePrint();
                            }
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Returning to menu");
                        break;
                    default:
                        Console.WriteLine("Invalid choice try again!");
                        Console.ReadLine();
                        break;
                }
                if (choice == "3")
                {
                    break;
                }

            }

        }
    }
}
