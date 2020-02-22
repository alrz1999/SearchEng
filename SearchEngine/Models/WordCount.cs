using System.ComponentModel.DataAnnotations;

namespace SearchEngine.Models
{
    public class WordCount
    {
        public WordCount(Word word, Document document, int count)
        {
            Word = word;
            Document = document;
            Count = count;
        }

        public WordCount()
        {
        }

        [Key]
        public int WordCountID { get; set; }

        public virtual Word Word { get; set; }

        public virtual Document Document { get; set; }

        public int Count { get; set; }

    }
}
