using System.Collections.Generic;

namespace IT008_O14_QLKS.Models
{
    public class Problem
    {
        public List<string> _ttproblem = new List<string>();
        public Problem(string problem, string soluong)
        {
            _ttproblem.Add(problem);
            _ttproblem.Add(soluong);
        }
    }
}