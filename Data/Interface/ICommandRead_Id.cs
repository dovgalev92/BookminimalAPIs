namespace BookMinAPIs.Data.Interface
{
    public interface ICommandRead_Id<out TOut>
    {
        TOut CommandReadById(int? id);
    }
}