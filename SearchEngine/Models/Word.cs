using System.ComponentModel.DataAnnotations;

namespace SearchEngine.Models
{
    public class Word
    {
        public Word(string str)
        {
            Str = str;
        }

        public Word(int wordID, string str)
        {
            WordID = wordID;
            Str = str;
        }

        public Word()
        {
        }

        [Key]
        public int WordID { get; set; }

        public string Str { get; set; }


        //public virtual ICollection<WordCount> Wordcounts { get; set; }

        //public virtual ICollection<WordIndex> WordIndices { get; set; }

    }
}
