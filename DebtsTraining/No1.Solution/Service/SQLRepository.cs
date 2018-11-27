using No1.Solution.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Service
{
    public class SQLRepository : IRepository
    {
        private List<string> passwordList;
        private IEnumerable<IPassword> passwordsChecker;

        public SQLRepository(IEnumerable<IPassword> passwordsChecker)
        {
            this.passwordList = new List<string>();
            this.passwordsChecker = passwordsChecker;
        }

        /// <summary>
        /// Create password for users
        /// </summary>
        /// <param name="password">Input characters set</param>
        /// <returns><see cref="Tuple{Boolean, String}"/> password</returns>
        public IEnumerable<Tuple<bool, string>> Create(string password)
        {
            List<Tuple<bool, string>> tuples = new List<Tuple<bool, string>>();

            bool valid = true;

            foreach (var item in passwordsChecker)
            {
                var result = item.VerifyPassword(password);

                if (result.Item1 == false) // ???
                {
                    tuples.Add(result);
                }                
            }

            if (valid) // ???
            {
                passwordList.Add(password);
            }

            return tuples;
        }
    }
}
