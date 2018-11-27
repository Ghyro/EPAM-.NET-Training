using No3.Solution.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution.Calculate
{
    /// <summary>
    /// The first way which use <see cref="List{T}"> and interface <see cref="IAveragingMethod"/>/>
    /// This interface implements two class: <see cref="Mean"/> and <see cref="Median"/>
    /// </summary>
    public class Calculator
    {
        public double CalculateAverage(List<double> values, IAveragingMethod averaging)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (averaging == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return averaging.DoSmth(values);
        }
    }
}
