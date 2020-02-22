using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class SearchEngine
    {
        private readonly IPrintable printer;

        public SearchEngine(IPrintable printer)
        {
            this.printer = printer;
        }

        public void Query()
        {
            while (true)
            {
                string query = Console.ReadLine().ToLower();
                this.printer.PrintResults(new Processor().ProcessQuery(query));
            }
        }
    }
}
