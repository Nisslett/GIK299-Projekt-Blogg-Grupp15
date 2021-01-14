using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GIK299_Projekt_Blogg
{
    public class Blogg
    {
        private List<Entry> EntryList;

        private readonly string FileName = "Blogg.json";
        public Blogg()
        {
            EntryList = new List<Entry>();
        }
        public void AddEntry(Entry ent)
        {
            EntryList.Add(ent);
        }

        public void ConsolePrintAll()
        {
            if (EntryList.Count == 0)
            {
                Console.WriteLine("No entries added.");
            }

            for (int i = 0; i < EntryList.Count; i++)
            {
                Console.WriteLine(EntryList[i].ConsoleString());
                //to make some more space
                Console.WriteLine();
            }
        }
        public void RemoveEntry(Entry ent)
        {
            EntryList.Remove(ent);
        }

        public void RemoveEntry(int index)
        {
            EntryList.RemoveAt(index);
        }

        public void SortDateTime()
        {
            //EntryList.Sort(Entry.DateCompare);
            EntryList.Sort();
        }
        public void SortDateTimeReverse()
        {
            //EntryList.Sort(Entry.DateCompareReverse);
            EntryList.Reverse();
        }

        public List<Entry> SearchTitle(string title)
        {
            List<Entry> foundList = new List<Entry>();
            for (int i = 0; i < EntryList.Count; i++)
            {
                if (EntryList[i].Title.ToLower().Contains(title.ToLower()))
                {
                    foundList.Add(EntryList[i]);
                }
            }
            return foundList;
        }

        public List<Entry> SearchAuthor(string author)
        {
            List<Entry> foundList = new List<Entry>();
            for (int i = 0; i < EntryList.Count; i++)
            {
                if (EntryList[i].Author.ToLower().Contains(author.ToLower()))
                {
                    foundList.Add(EntryList[i]);
                }
            }
            return foundList;
        }

        public void SaveToFile()
        {
            if (EntryList.Count > 0)
            {
                //encodes our EntryList into a string with JsonSerializer
                string jsonString = JsonSerializer.Serialize(EntryList);
                //Writes all contents of the Specifed string (jsonStr) 
                //to the specifed file (Filename)
                File.WriteAllText(FileName, jsonString);
            }
        }

        public void LoadFromFile()
        {
            if (File.Exists(FileName))
            {
                //Reads in all text in the specified File (FileName) and stores it in the jsonString
                string jsonString = File.ReadAllText(FileName);
                //decodes the string with JsonSerializer.Deserialize to a new List<Entry> and set the decoded list to the bloggs current list
                EntryList = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            }
        }
    }
}