using SearchEngine.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Processor
    {
        public static int PROXIMITY_MAX_DISTANCE = 5;
        private Dictionary<int, Result> results = new Dictionary<int, Result>();

        public Processor()
        {
            Console.WriteLine("ZGH Search Engine\nSearch Results:");
        }

        public List<Result> ProcessQuery(string query)
        {
            string[] wordsToFind = ExtractQueryWords(query);
            FillResults(wordsToFind);
            SetResultsScore(wordsToFind);
            ProximityFilter(wordsToFind);
            return GetSortedResult();

        }

        private void FillResults(string[] wordsToFind)
        {
            List<int> foundDocs = FindAllMatches(wordsToFind);
            if (foundDocs != null)
            {
                foreach (int docIndex in foundDocs)
                {
                    results.Add(docIndex, new Result(docIndex, 0));
                }
            }
        }

        private List<Result> GetSortedResult()
        {
            List<Result> result = new List<Result>(results.Values);
            result.Sort((result1, result2) => result1.Score.CompareTo(result2.Score));
            return result;
        }

        private String[] ExtractQueryWords(string query)
        {
            return Splitter.Split(query);
        }

        private void ProximityFilter(string[] words)
        {
            ArrayList toBeRemovedDocs = new ArrayList();
            using (WordContext context = new WordContextFactory().Create())
            {
                foreach (int docIndex in results.Keys)
                {
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        var first = words[i];
                        var second = words[i + 1];
                        int firstIndex = context.WordsIndex.Where(x => x.WordCount.Word.Str == first && x.WordCount.Document.DocID == docIndex).Select(x => x.StartIndex).FirstOrDefault();
                        int secondIndex = context.WordsIndex.Where(x => x.WordCount.Word.Str == second && x.WordCount.Document.DocID == docIndex).Select(x => x.StartIndex).FirstOrDefault();
                        if (Math.Abs(firstIndex - secondIndex) > PROXIMITY_MAX_DISTANCE)
                        {
                            toBeRemovedDocs.Add(docIndex);
                        }
                    }
                }
            }
            foreach (int index in toBeRemovedDocs)
            {
                results.Remove(index);
            }
        }

        private void SetResultsScore(string[] wordsToFind)
        {
            int score;
            foreach (string word in wordsToFind)
            {
                foreach (int docIndex in results.Keys)
                {
                    using (WordContext context = new WordContextFactory().Create())
                    {
                        if (!context.WordCounts.Any(x => x.Document.DocID == docIndex))
                            continue;
                        score = context.WordCounts.Where(x => x.Word.Str == word && x.Document.DocID == docIndex).Select(x => x.Count).FirstOrDefault();
                        results[docIndex].ChangeScore(score);
                    }
                }
            }
        }

        private List<int> FindAllMatches(string[] wordsToFind)
        {
            List<int> foundDocIndexes = null;
            foreach (string word in wordsToFind)
            {
                List<int> foundDocIndexesForWord = GetFoundDocsIndexForWord(word);
                if (foundDocIndexesForWord != null)
                {
                    if (foundDocIndexes == null)
                        foundDocIndexes = new List<int>(foundDocIndexesForWord).Distinct().ToList();
                    else
                    {
                        foundDocIndexes = new List<int>(foundDocIndexes.Intersect(foundDocIndexesForWord));
                    }
                }
            }
            return foundDocIndexes;
        }


        private List<int> GetFoundDocsIndexForWord(String word)
        {
            using (WordContext context = new WordContextFactory().Create())
            {
                
                if (context.Words.Any(x => x.Str == word))
                {
                    DetailsOfWord detailsOfWord = new DetailsOfWord(word);
                    return context.WordCounts.Where(x => x.Word.Str == word).Select(x => x.Document.DocID).ToList();
                }
                return null;
            }
        }
    }
}
