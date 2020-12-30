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
            }

            //Entry newEntry=new Entry("","","");
        }

        public int NumberOfEntries()
        {
            //TODO
            return 0;
        }

        public void RemoveEntry(Entry ent)
        {
            EntryList.Remove(ent);
        }

        public void RemoveEntry(int index)
        {
            EntryList.RemoveAt(index);
        }

        public void SortDateTime(bool c)
        {
            if (c)
            {
                EntryList.Sort(Entry.DateCompare);
            }
            else
            {
                EntryList.Sort(Entry.DateCompareReverse);
            }
        }
        public List<Entry> Search(string title)
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

        public void SaveToFile()
        {

            if (EntryList.Count > 0)
            {
                string jsonStr = JsonSerializer.Serialize(EntryList);
                using (StreamWriter sw = File.CreateText(FileName))
                {
                    sw.WriteLine(jsonStr);
                    sw.Close();
                }
            }

        }

        public void LoadFromFile()
        {
            if (File.Exists(FileName))
            {
                string jsonstr;
                using (StreamReader sr = File.OpenText(FileName))
                {
                    jsonstr = sr.ReadToEnd();
                    sr.Close();
                }
                List<Entry> dejsonfile = JsonSerializer.Deserialize<List<Entry>>(jsonstr);
                EntryList = dejsonfile;
            }
        }
    }
}