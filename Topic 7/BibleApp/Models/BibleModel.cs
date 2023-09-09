using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibleApp.Models
{
    public class BibleModel
    {

        private string[] BookName = new string[66]{ "Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1Samuel","2Samuel","1Kings","2Kings",
            "1Chronicles","2Chronicles","Ezra","Nehemiah","Esther","Job","Psalm","Proverbs","Ecclesiastes","SongofSolomon","Isaiah",
            "Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah",
            "Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1Corinthians","2Corinthians","Galatians",
            "Ephesians","Philippians","Colossians","1Thessalonians","2Thessalonians","1Timothy","2Timothy","Titus","Philemon","Hebrews",
            "James","1Peter","2Peter","1John","2John","3John","Jude","Revelation"
        };

        public int Book { get; set; }
        public string BookText { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }



        public BibleModel(int book, int chapter, int verse, string text)
        {
            BookText = BookName[book - 1];
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
