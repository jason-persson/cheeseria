namespace Domain
{
    public interface ICheeseRepository
    {
        Task<IEnumerable<Cheese>> GetCheeses();
    }
}