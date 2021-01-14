using System;

namespace GIK299_Projekt_Blogg
{
    public class Entry : IComparable<Entry>
    {
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
        public string ConsoleString()
        {
            return $"TimeOfEntry: {TimeOfEntry}\nTitle: {Title}\nAuthor: {Author}\nText:\n{Text}";
        }
        public int CompareTo(Entry ent){
            return ent.TimeOfEntry.CompareTo(this.TimeOfEntry);
        }
    }
}