using No3.Solution.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution.Ways
{
    /// <summary>
    /// The first way
    /// </summary>
    public class Mean : IAveragingMethod
    {
        public double DoSmth(List<double> values)
        {
            return values.Sum() / values.Count;
        }
    }
}
