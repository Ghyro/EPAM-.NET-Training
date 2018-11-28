using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution.Interface
{
    /// <summary>
    /// Use interface for two ways to execute calculate averaging
    /// </summary>
    public interface IAveragingMethod
    {
        double DoSmth(List<double> list);
    }
}
