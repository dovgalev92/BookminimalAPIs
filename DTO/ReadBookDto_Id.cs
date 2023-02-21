using System.ComponentModel.DataAnnotations;
using BookMinAPIs.Models.Entity;
namespace BookMinAPIs.DTO
{
   public class ReadBookDto_Id
   {
        public int BookId {get;set;}
        public string Title {get;set;} = string.Empty;
        public string Description {get;set;} =string.Empty;
        [DataType(DataType.Date)]
        public DateTime Publishen {get;set;}
        public decimal Price {get;set;}
        public ICollection<Review>? Reviews {get;set;}
   }
}