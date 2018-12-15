using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLL.WEB.Models
{
    public class DepositWithdrawViewModel
    {
        /// <summary>
        /// The ID of the personal account
        /// </summary>
        [Display(Name = "Account Id")]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The amount of balance for deposit or withdraw
        /// </summary>
        [Display(Name = "Amount of money")]
        [Required]
        public decimal Amount { get; set; }
    }
}