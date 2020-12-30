using System;

namespace GIK299_Projekt_Blogg
{
    public class Entry
    {
        public int GlobalEntryInt { get; set; }
        public DateTime TimeOfEntry { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public Entry(string title, string author, string text)
        {
            this.TimeOfEntry = DateTime.Now;
            this.Title = title;
            this.Author = author;
            this.Text = text;
        }
        public Entry()
        {
            this.TimeOfEntry = DateTime.Now;
            this.Title = "";
            this.Author = "";
            this.Text = "";
        }

        public void ConsolePrint()
        {
            Console.WriteLine($"TimeOfEntry: {TimeOfEntry}\nTitle: {Title}\nAuthor: {Author}\nText: {Text}");
        }

        public static int DateCompare(Entry entA, Entry entB)
        {
            int value = entA.TimeOfEntry.CompareTo(entB.TimeOfEntry);
            if (value > 0)
            {
                return -1;
            }
            if (value < 0)
            {
                return 1;
            }
            return 0;
        }

        public static int DateCompareReverse(Entry entA, Entry entB)
        {
            return entA.TimeOfEntry.CompareTo(entB.TimeOfEntry);
        }

        public override string ToString()
        {
            return ""; // TODO
        }
    }
}