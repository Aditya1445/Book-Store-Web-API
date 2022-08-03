using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApi.DTO
{
    public class SignUpModelDTO
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
