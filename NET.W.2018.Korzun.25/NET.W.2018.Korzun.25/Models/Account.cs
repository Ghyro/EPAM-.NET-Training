using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET.W._2018.Korzun._25.Models
{
    public class Account
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field must have value.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "String length must be from 3 to 50 symbols")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field must have value.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "String length must be from 3 to 50 symbols")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field must have value.")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "This field must have value.")]
        [Display(Name = "Type")]
        public int AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }
    }
}