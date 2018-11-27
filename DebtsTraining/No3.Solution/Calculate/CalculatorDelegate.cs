using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution.Calculate
{
    /// <summary>
    /// The second way which use delegate <see cref="CalcDeleg"/>
    /// </summary>
    public static class CalculatorDelegate
    {
        public delegate double CalcDeleg(List<double> list); // we could use Func

        public static double CalculateAverage(this List<double> values, CalcDeleg calcDeleg)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (calcDeleg == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return calcDeleg(values);
        }
    }
}
