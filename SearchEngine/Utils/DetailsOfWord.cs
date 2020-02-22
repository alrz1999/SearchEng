using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class DetailsOfWord
    {
        private String word;

        /**
         * A hash map to link indexes and numOfWords in doc
         */
        private Dictionary<int, int> numOfWordInDocs;
        //todo for multiple occurrences in one doc can add ArrayList of Integer to save indexes
        /**
         * key: index of doc ; value: index of word in doc
         */
        private Dictionary<int, int> indexInDoc;
        
        public DetailsOfWord(String word)
        {
            this.word = word;
            this.numOfWordInDocs = new Dictionary<int, int>();
            this.indexInDoc = new Dictionary<int, int>();
        }

        public void AddWordToDocIndex(int indexOfDoc)
        {
            if (!numOfWordInDocs.Keys.Contains(indexOfDoc))
            {
                numOfWordInDocs.Add(indexOfDoc, 1);
            }
            else
            {
                numOfWordInDocs[indexOfDoc] =  numOfWordInDocs[indexOfDoc] + 1;
            }
        }

        public void AddIndexOfWordInDoc(int indexOfDoc, int indexOfWord)
        {
            this.indexInDoc[indexOfDoc] = indexOfWord;
        }

        public Dictionary<int, int> GetNumOfWordInDocs()
        {
            return numOfWordInDocs;
        }

        public Dictionary<int, int> GetIndexInDoc()
        {
            return indexInDoc;
        }
    }
}
