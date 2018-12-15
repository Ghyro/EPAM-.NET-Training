using BLL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLL.WEB.Models
{
    public class AccountViewModel
    {
        /// <summary>
        /// The ID of the personal account
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// The account holder name
        /// </summary>
        [Required(ErrorMessage = "This field mustn't be empty!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "String length must be from 3 to 50 symbols")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// The account holder surname
        /// </summary>
        [Required(ErrorMessage = "This field mustn't be empty!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "String length must be from 3 to 50 symbols")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// The account current amount
        /// </summary>
        [Required(ErrorMessage = "This field mustn't be empty!")]
        [Display(Name = "Balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// The account bonus points 
        /// </summary>
        [Required]
        public int Bonus { get; set; }

        /// <summary>
        /// The account status
        /// </summary>
        [Required]
        public AccountStatus Status { get; set; }

        /// <summary>
        /// The account type (base, gold, platinum)
        /// </summary>
        [Required]
        public string AccountType { get; set; }
    }
}