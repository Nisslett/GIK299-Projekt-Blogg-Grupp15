using System.Collections.Generic;
using System;

namespace GIK299_Projekt_Blogg
{
    public class Blogg
    {
        private List<Entry> EntryList;

        public Blogg()
        {
            EntryList=new List<Entry>();
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

        public void RemoveEntry( Entry ent)
        {
            EntryList.Remove(ent);
        }

        public void RemoveEntry( int index)
        {
            EntryList.RemoveAt(index);
        }
        
        public void SortDateTime(bool c)
        {
            if(c)
            {
                EntryList.Sort(Entry.DateCompare);
            }
            else
            {
                EntryList.Sort(Entry.DateCompareReverse);
            }
        }
        public Entry Search(string title)
        {
            //TODO
            return new Entry("","",""); //temporärt
        }

        public void SaveToFile()
        {
            //TODO
        }

        public void LoadFromFile()
        {
            //TODO
        }
    }
}