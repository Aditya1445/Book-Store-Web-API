using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Models
{
    public class Books
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Key]
        public int Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int price { get; set; }

        public DateTime datePublished { get; set; }

        public string author { get; set; }

        public int numberOfCopies { get; set; }

        public Books()
        {
            datePublished = DateTime.Now;
        }
    }
}
