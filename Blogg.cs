using System;
using System.Collections.Generic;
using System.IO;

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
            //We open a StreamWriter to file with name in (FileName) that will create the file if it
            //doesn't exist and overwrite it's constens if it does with the contens of our EntryList
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
                        //items variable is to count how many new strings we can read in from the text file.
                        items = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            
                            if (!sr.EndOfStream)
                            {
                                //as long as we are'nt at the en of the file read in a new line (sr.ReadLine())
                                readstr[i] = sr.ReadLine();
                                items = i;
                            }
                            else
                            {
                                //if we are at the en of the file break the loop and set items=0;
                                items = 0;
                                break;
                            }
                        }
                        //aslong as we have items!=0 we have 4 string from the text file to convert to
                        //a new Entry object to add to our loadedlist
                        if (items != 0)
                        {
                            Entry newent = new Entry();
                            DateTime newDT;
                            //Here we try to convert the first string in readstr array to a DateTime object
                            //if that fails then the contens of this if stament bellow will run and basicly
                            //generate an Error and exit the LoadFromFile() function
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
                            // adds the new entry to the new list (loadedlist)
                            loadedlist.Add(newent);
                        }
                    } while (items != 0);
                    sr.Close();
                }
                //and when we're done replace the existing list in our Blogg with the loaded one.
                EntryList = loadedlist;
            }
        }
    }
}