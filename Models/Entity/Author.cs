namespace BookMinAPIs.Models.Entity
{
    public class Author
    {
        public int AuthorId {get;set;}
        public string Name {get;set;} = string.Empty;
        public ICollection<Book>? Books {get;set;}
    }
}