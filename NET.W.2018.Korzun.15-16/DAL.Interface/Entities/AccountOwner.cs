using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Entities
{
    /// <summary>
    /// The entities for work with <see cref="IRepository"/>
    /// </summary>
    public class AccountOwner
    {
        /// <summary>
        /// The ID of the personal account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The account name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The account surname
        /// </summary>
        public string Surname { get; set; }
    }
}
