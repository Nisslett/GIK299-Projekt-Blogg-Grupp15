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
                //return;
            }
            
            for (int i = 0; i < EntryList.Count; i++)
            {
                EntryList[i].ConsolePrint();
            }
        }
    }
}