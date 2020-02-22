using System.ComponentModel.DataAnnotations;

namespace SearchEngine.Models
{
    public class WordIndex
    {
        public WordIndex(WordCount wordCount, int startIndex) : this(startIndex)
        {
            WordCount = wordCount;
        }

        public WordIndex(int startIndex)
        {
            StartIndex = startIndex;
        }

        [Key]
        public int WordIndexID { get; set; }

        public virtual WordCount WordCount { get; set; }

        public int StartIndex { get; set; }

    }
}
