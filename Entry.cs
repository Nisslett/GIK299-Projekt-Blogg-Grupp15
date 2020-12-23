using System;

namespace GIK299_Projekt_Blogg
{
    public class Entry
    {
        public DateTime TimeOfEntry;
        public string Title;

        public string Author;

        public string Text;

        public Entry(string title,string author,string text)
        {
            this.TimeOfEntry=DateTime.Now;
            this.Title=title;
            this.Author=author;
            this.Text=text;
        }

        public void ConsolePrint()
        {
            Console.WriteLine($"TimeOfEntry:{TimeOfEntry}\nTitle: {Title}\nAuthor: {Author}\nText: {Text}");
        }
    }
}