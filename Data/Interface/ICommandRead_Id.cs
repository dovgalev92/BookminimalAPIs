namespace BookMinAPIs.Data.Interface
{
    public interface ICommandRead_Id<in TIn, out TOut>
    {
        TOut CommandReadById(TIn bookId);
    }
}