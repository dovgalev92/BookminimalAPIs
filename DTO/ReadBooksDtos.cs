using BookMinAPIs.Models.Entity;
namespace BookMinAPIs.DTO
{
    public class ReadBooksDtos
    {
        public int BookId {get;set;}
        public string Title {get;set;} = string.Empty;
        public decimal Price {get;set;}
        public int AuthorId {get;set;}
        public Author? Author {get;set;}
    }
}