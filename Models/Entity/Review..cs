namespace BookMinAPIs.Models.Entity
{
    public class Review
    {
        public int ReviewId {get;set;}
        public string Comments {get;set;} = string.Empty;
        public int BookId {get;set;}
    }
}