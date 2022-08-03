using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApi.DTO
{
    public class LoginModelDTO
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Required, EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
