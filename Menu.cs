using System;
using System.Collections.Generic;

namespace GIK299_Projekt_Blogg
{
    public class Menu
    {
        private Blogg OurBlogg;
        //Constructor
        public Menu()
        {
            //Useing the constructor to start the program.
            MainMenu();
        }

        //Menu strings
        private static readonly string[] MainMenuText ={
            "Welcome to Nils, Adams and Tores blogg!",
            "1. Add an entry to the blogg.",
            "2. Print all blogg entries.",
            "3. Sort.",
            "4. Seach in the blogg",
            "E. Exit."
        };

        private static readonly string[] SortMenuText ={
            "1. Sort from newest to oldest",
            "2. Sort from oldest to newest",
            "3. Return to menu."
        };

        private static readonly string[] SearchMenuText ={
            "1. Search by title.",
            "2. Search by author.",
            "3. Return to menu."
        };
        //Generic functions for the menu

        //This function prints out a string array in a box
        private void PrintMenuText(string[] menutext)
        {
            int maxlength = 0;
            foreach (string line in menutext)
            {
                if (line.Length > maxlength)
                {
                    maxlength = line.Length;
                }
            }
            int paddingWidth = 2, borderWidth = 2;
            string paddingString = new string(' ', paddingWidth),
            borderString = new string('|', borderWidth),
            boxlineString = new string('=', maxlength + paddingWidth * 2 + borderWidth * 2);
            Console.WriteLine(boxlineString);
            foreach (string line in menutext)
            {
                Console.Write(borderString);
                Console.Write(paddingString);
                Console.Write(line);
                Console.Write(new string(' ', maxlength - line.Length));
                Console.Write(paddingString);
                Console.WriteLine(borderString);
            }
            Console.WriteLine(boxlineString);
            Console.WriteLine("Type in your choice:");
        }
        private void PressAnyKey(string text)
        {
            Console.Write(text);
            Console.ReadKey();
        }
        private void PressAnyKey()
        {
            PressAnyKey("Press any key to continue . . .");
        }

        private string InputString()
        {
            string inputString = null;
            while (String.IsNullOrEmpty(inputString) || String.IsNullOrWhiteSpace(inputString))
            {
                if (inputString != null)
                {
                    Console.WriteLine("Input cannot be empty or contain only white spaces. Please try again!");
                }
                inputString = Console.ReadLine();
            }
            return inputString;
        }

        private int NumOfLinebreaks(string str){
            int count=0;
            int lastindex=0;
            do{
                if(count==0)
                {
                    lastindex=str.IndexOf('\n');
                }
                else
                {
                    lastindex=str.IndexOf('\n',lastindex+1);
                }
                if(lastindex!=-1)
                {
                    count++;
                }
            }while(lastindex!=-1);
            return count;
        }

        private void staggeredOutput(List<Entry> entrylist)
        {
            // int windowHeight=Console.WindowHeight,tmpCount=0,lastCount=0;
            // foreach (Entry entry in entrylist)
            // {
            //     lastCount=NumOfLinebreaks(entry.ConsoleString());
            //     if(tmpCount+lastCount>windowHeight)
            //     {

            //     }
            // }
        }

        //Menu functions
        private void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            OurBlogg = new Blogg();
            OurBlogg.LoadFromFile();
            while (true)
            {
                Console.Clear();
                PrintMenuText(MainMenuText);
                string menuSwitch = InputString().ToUpper();
                switch (menuSwitch)
                {
                    case "1":
                        MakeNewEntry();
                        break;
                    case "2":
                        OurBlogg.ConsolePrintAll();
                        PressAnyKey();
                        break;
                    case "3":
                        SortMenu();
                        break;
                    case "4":
                        SearchBloggMenu();
                        break;
                    case "E":
                        Console.WriteLine("Exitting program!");
                        break;
                    default:
                        PressAnyKey("Invalid input try again!");
                        break;
                }
                if (menuSwitch == "E")
                {
                    break;
                }
                
            }
            OurBlogg.SaveToFile();
            Console.ResetColor();
        }

        private void MakeNewEntry()
        {
            Console.WriteLine("Input the blogg entry's author name:");
            string author = InputString();
            Console.WriteLine("Input the blogg entry's title:");
            string title = InputString();
            Console.WriteLine("Input the blogg text content (2 linebreaks \\n will exit this section):");
            int newlineCount = 0;
            string text = "";
            string temporary_str = null;
            while (newlineCount < 1)
            {
                if (temporary_str != null)
                {
                    newlineCount++;
                }
                temporary_str = Console.ReadLine();
                //if your input is NOT empty, enter this if-statement
                if (!string.IsNullOrEmpty(temporary_str) && !string.IsNullOrWhiteSpace(temporary_str))
                {

                    if (String.IsNullOrEmpty(text))
                    {
                        //makes is so the text doesn't start with a newline
                        text += temporary_str;
                    }
                    else if (newlineCount == 1)
                    {
                        // adds a linebreak
                        text += "\n" + temporary_str;
                    }
                    newlineCount = 0;
                }
            }
            OurBlogg.AddEntry(new Entry(title, author, text));
        }

        private void SortMenu()
        {
            string choice;
            while (true)
            {
                Console.Clear();
                PrintMenuText(SortMenuText);
                choice = InputString().ToUpper();
                switch (choice)
                {
                    case "1":
                        OurBlogg.SortDateTime();
                        Console.WriteLine("The blogg has now been sorted by newest to oldest.");
                        PressAnyKey();
                        break;
                    case "2":
                        OurBlogg.SortDateTimeReverse();
                        Console.WriteLine("The blogg has now been sorted by oldest to newest.");
                        PressAnyKey();
                        break;
                    case "E":
                        break;
                    default:
                        PressAnyKey("Invalid choice try again!");
                        break;
                }
                if (choice == "E")
                {
                    break;
                }
            }
        }

        private void SearchBloggMenu()
        {
            string choice;
            while (true)
            {
                Console.Clear();
                PrintMenuText(SearchMenuText);
                choice = InputString().ToUpper();
                switch (choice)
                {
                    case "1":
                        SearchBloggTitle();
                        PressAnyKey();
                        break;
                    case "2":
                        SearchBloggAuthor();
                        PressAnyKey();
                        break;
                    case "E":
                        break;
                    default:
                        PressAnyKey("Invalid choice try again!");
                        break;
                }
                if (choice == "E")
                {
                    break;
                }
            }
        }
        private void SearchBloggTitle()
        {
            Console.WriteLine("Type in the title you are searching for:");
            List<Entry> foundTitle = OurBlogg.SearchTitle(InputString());
            if (foundTitle.Count == 0)
            {
                Console.WriteLine("No Entry found in the search!");
            }
            else
            {
                foreach (Entry entry in foundTitle)
                {
                    Console.WriteLine(entry.ConsoleString());
                }
            }
        }
        private void SearchBloggAuthor()
        {
            Console.WriteLine("Type in the author you are searching for:");
            List<Entry> foundAuthor = OurBlogg.SearchAuthor(InputString());
            if (foundAuthor.Count == 0)
            {
                Console.WriteLine("No Entry found in the search!");
            }
            else
            {
                foreach (Entry entry in foundAuthor)
                {
                    Console.WriteLine(entry.ConsoleString());
                }
            }
        }
    }

}