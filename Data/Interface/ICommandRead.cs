namespace BookMinAPIs.Data.Interface
{
    public interface ICommandRead<Y>
    {
        Task<IEnumerable<Y>> CommandAllBookRead();
    }
}