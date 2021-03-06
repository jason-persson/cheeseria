namespace Domain
{
    public interface ICheeseRepository
    {
        Task<Cheese> Add(Cheese cheese);
        Task Delete(uint id);
        Task<Cheese> Get(uint id);
        Task<Cheese> Update(Cheese cheese);
        Task<IEnumerable<Cheese>> GetAll();
    }
}