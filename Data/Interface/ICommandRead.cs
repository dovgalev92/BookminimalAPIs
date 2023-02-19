namespace BookMinAPIs.Data.Interface
{
    public interface ICommandRead<T>
    {
        Task<IEnumerable<T>> CommandAllBookRead();
    }
}