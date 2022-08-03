using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
