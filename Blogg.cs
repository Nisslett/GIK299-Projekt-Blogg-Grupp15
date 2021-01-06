using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GIK299_Projekt_Blogg
{
    public class Blogg
    {
        private List<Entry> EntryList;

        private string FileName = "Blogg.json";
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
                EntryList[i].ConsolePrint();
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
            EntryList.Sort(Entry.DateCompare);
        }
        public void SortDateTimeReverse()
        {
            EntryList.Sort(Entry.DateCompareReverse);
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
                string jsonStr = JsonSerializer.Serialize(EntryList);
                //opens a file to write the serlized string to
                using (StreamWriter sw = File.CreateText(FileName))
                {
                    //writes the string
                    sw.WriteLine(jsonStr);
                    //closes the StreamWriter link to the file
                    sw.Close();
                }
            }

        }

        public void LoadFromFile()
        {
            if (File.Exists(FileName))
            {
                //temporary string to store all the text in the json file
                string jsonstr;
                using (StreamReader sr = File.OpenText(FileName))
                {
                    //reads in all the text from the file
                    jsonstr = sr.ReadToEnd();
                    sr.Close();
                }
                //decodes the string with JsonSerializer.Deserialize to a new List<Entry>
                List<Entry> dejsonlist = JsonSerializer.Deserialize<List<Entry>>(jsonstr);
                //set the decodedlist to the bloggs current list
                EntryList = dejsonlist;
            }
        }
    }
}