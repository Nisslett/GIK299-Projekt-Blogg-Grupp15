using System;

namespace GIK299_Projekt_Blogg
{
    public class Entry
    {
        public int GlobalEntryInt; 
        public DateTime TimeOfEntry; 
        public string Title;
        public string Author;
        public string Text;

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
            //this is to reverse the greater and less then vaule from DateTime.CompareTo()
            //so what we want to do is to make DateTime.CompareTo() negativ when it's postiv and 
            //postiv when it's negativ.
            int value = entA.TimeOfEntry.CompareTo(entB.TimeOfEntry);
            if (value >= 1) // when postiv
            {
                return -1;// make negativ
            }
            if (value <= -1)// when negativ
            {
                return 1; // make postiv
            }
            return 0;
        }

        public static int DateCompareReverse(Entry entA, Entry entB)
        {
            return entA.TimeOfEntry.CompareTo(entB.TimeOfEntry);
        }
    }
}