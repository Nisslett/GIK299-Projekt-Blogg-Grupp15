using System;
using System.Collections.Generic;
using System.IO;
//using System.Text.Json;

namespace GIK299_Projekt_Blogg
{
    public class Blogg
    {
        private List<Entry> EntryList;

        private string FileName = "Blogg.txt";
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
            using (StreamWriter sw = File.CreateText(FileName))
            {
                for (int i = 0; i < EntryList.Count; i++)
                {
                    sw.WriteLine(EntryList[i].TimeOfEntry);
                    sw.WriteLine(EntryList[i].Title);
                    sw.WriteLine(EntryList[i].Author);
                    sw.WriteLine(EntryList[i].Text.Replace("\n", "\\n"));
                }
                sw.Close();
            }
        }

        public void LoadFromFile()
        {
            if (File.Exists(FileName))
            {
                List<Entry> loadedlist = new List<Entry>();
                using (StreamReader sr = File.OpenText(FileName))
                {
                    int items;
                    do
                    {
                        string[] readstr = new string[4];
                        items = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (!sr.EndOfStream)
                            {
                                readstr[i] = sr.ReadLine();
                                items = i;
                            }
                            else
                            {
                                items = 0;
                                break;
                            }
                        }
                        if (items != 0)
                        {
                            Entry newent = new Entry();
                            DateTime newDT;
                            if (!DateTime.TryParse(readstr[0], out newDT))
                            {
                                sr.Close();
                                Console.WriteLine($"\nError Could Not Load List from file \"{FileName}\"!\nDateTime Parse failed!");
                                Console.ReadLine();
                                return;
                            }
                            newent.TimeOfEntry = newDT;
                            newent.Title = readstr[1];
                            newent.Author = readstr[2];
                            newent.Text = readstr[3].Replace("\\n", "\n");
                            loadedlist.Add(newent);
                        }
                    } while (items != 0);
                    sr.Close();
                }
                EntryList = loadedlist;
            }
        }
    }
}