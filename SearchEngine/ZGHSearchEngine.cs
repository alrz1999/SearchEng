using SearchEngine.DAL;
using SearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SearchEngine
{
    class ZGHSearchEngine
    {
        public static void Main(string[] args)
        {
            IPrintable printer = new Printer();
            SearchEngine searchEngine = new SearchEngine(printer);
            searchEngine.Query();
            
        }
    }
}
