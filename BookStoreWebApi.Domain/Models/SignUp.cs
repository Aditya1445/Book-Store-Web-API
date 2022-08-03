using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Models
{
    public class SignUp
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required, EmailAddress]
        public string email { get; set; }

        [Required]
        [Compare("confirmPassword")]
        public string password { get; set; }

        [Required]
        public string confirmPassword { get; set; }

    }
}
