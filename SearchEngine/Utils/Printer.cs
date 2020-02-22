using SearchEngine.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Printer : IPrintable
    {
        public void PrintResults(List<Result> results)
        {
            using (WordContext context = new WordContextFactory().Create())
            {
                foreach (Result result in results)
                {
                    Console.WriteLine(result.Score + "     " + context.Documents.Where(x =>x.DocID == result.Index).Select(x=>x.Text).FirstOrDefault());
                }
            }


        }
    }
}
