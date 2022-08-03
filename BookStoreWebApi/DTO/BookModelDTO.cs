using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApi.DTO
{
    public class BookModelDTO
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [Key]
        public int Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int price { get; set; }

        //public DateTime datePubished { get; set; }

        public string author { get; set; }

        //public int numberOfCopies { get; set; }
    }
}
