using BookMinAPIs.Models.Entity;
namespace BookMinAPIs.DTO
{
    public class CreateBookDtos
    {
        public int BookId {get;set;}
        public string Title {get;set;} = string.Empty;
        public string Description {get;set;} =string.Empty;
        public DateTime Publishen {get;set;}
        public decimal Price {get;set;}
        public int AuthorId {get;set;}
        public Author? Author {get;set;}
    }
}
