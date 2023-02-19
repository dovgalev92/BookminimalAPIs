namespace BookMinAPIs.DTO
{
    public class UpdateBookDtos
    {
        public int BookId {get;set;}
        public string Description {get;set;} = string.Empty;
        public decimal Price {get;set;}
    }
}