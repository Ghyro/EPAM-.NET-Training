using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.DTO
{
    /// <summary>
    /// The account owner (entities)
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
