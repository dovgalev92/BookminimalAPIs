namespace BookMinAPIs.Data.Interface
{
    public interface ICommandUpdate<in TIn>
    {
        Task CommandUpdate(TIn bookUpt);
    }
}