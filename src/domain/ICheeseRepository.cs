namespace Domain
{
    public interface ICheeseRepository
    {
        Task AddCheese(Cheese cheese);
        Task<IEnumerable<Cheese>> GetCheeses();
    }
}