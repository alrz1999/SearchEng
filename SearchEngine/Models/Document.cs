using System.ComponentModel.DataAnnotations;

namespace SearchEngine.Models
{
    public class Document

    {
        

        [Key]
        public int DocID { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

    }
}
