using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLL.WEB.Models
{
    public class TransactionViewModel
    {
        /// <summary>
        /// From the account
        /// </summary>
        [Display(Name = "From Account")]
        [Required]
        public int FromAccount { get; set; }

        /// <summary>
        /// To the account
        /// </summary>
        [Display(Name = "To Account")]
        [Required]
        public int ToAccount { get; set; }

        /// <summary>
        /// Amount of money for transfer
        /// </summary>
        [Display(Name = "Amount of money")]
        [Required]
        public decimal AmountOfMoney { get; set; }
    }
}