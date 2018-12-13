using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET.W._2018.Korzun._25.Models
{
    public class AccountType
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field must have value.")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "String length must be from 10 to 30 symbols")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "This field must have value.")]
        [Display(Name = "Bonus")]
        [Range(1, 50, ErrorMessage = "Range Exception")]
        public int Bonus { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public AccountType()
        {
            Accounts = new List<Account>();
        }

    }
}