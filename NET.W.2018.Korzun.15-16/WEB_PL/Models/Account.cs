using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_PL.Models
{
    public class Account
    {        
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "This field mustn't be empty!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field mustn't be empty!")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field mustn't be empty!")]
        [Display(Name = "Balance")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Bonus")]
        public int Bonus { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string AccountType { get; set; }
    }
}