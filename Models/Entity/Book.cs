using System.ComponentModel.DataAnnotations;
namespace BookMinAPIs.Models.Entity
{
    public class Book
    {
        [Key]
        public int BookId {get;set;}
        [Required]
        public string Title {get;set;} = string.Empty;
        [Required]
        public string Description {get;set;} =string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime Publishen {get;set;}
        [Required]
        public decimal Price {get;set;}
        public int AuthorId {get;set;}
        public Author? Authors {get;set;}
        public ICollection<Review>? Reviews {get;set;}
    
    }
}