using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Result
    {
        /**
            * @param index: index of document
            * @param score : score of document
            */
        public int Index { get; }
        public int Score { get; set; }

        public Result(int index, int score)
        {
            this.Index = index;
            this.Score = score;
        }

        public void ChangeScore(int change) => this.Score += change;

    }
}
