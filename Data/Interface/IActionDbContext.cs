namespace BookMinAPIs.Data.Interface
{
    public interface IActionDbContext<in TIn, T>
    {
        Task CommandCreateAuthor(T author);
        Task CommandBookCreate(int id, TIn bookCrt);
        Task CommandDeleteBook(int? bookId);
        Task CommandUpdate(TIn bookUpt);
        Task SaveChangesAsync();
    }
}