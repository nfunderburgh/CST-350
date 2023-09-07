using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibleApp.Models
{
    public class BibleModel
    {
        public int Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }



        public BibleModel(int book, int chapter, int verse, string text)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
        }

        public BibleModel()
        {

        }
    }
}
