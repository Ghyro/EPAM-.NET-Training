using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No6.Solution
{
    public sealed class Generator
    {
        public delegate T MyGenerate<T>(T a, T b); // Could use Func<T,T,T> delegate

        /// <summary>
        /// <see cref="IEnumerable{T}"/> basic generator
        /// </summary>
        /// <typeparam name="T">Generic input type</typeparam>
        /// <param name="x">The first value</param>
        /// <param name="y">The second value</param>
        /// <param name="n">Iteration count</param>
        /// <param name="generate"></param>
        /// <returns></returns>
        public IEnumerable<T> Generate<T>(T x, T y, int n, MyGenerate<T> generate)
        {
            for (int i = 0; i <= n; i++)
            {
                var result = generate(x, y);

                yield return result;

                x = y;

                y = result;
            }
        }
    }
}
