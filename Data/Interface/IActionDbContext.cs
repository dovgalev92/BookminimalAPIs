namespace BookMinAPIs.Data.Interface
{
    public interface IActionDbContext<in TIn>
    {
        Task CommandBookCreate(TIn bookCrt);
        void CommandDeleteBook(int? bookId);
        Task SaveChangesAsync();

    }
}