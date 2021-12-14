namespace Domain
{
    /// An in-memory collection to serve as the persistence layer in the PZ Cheeseria demo application
    /// 
    /// If I had more time I'd put a domain object layer above this, and the domain layer would make use of
    /// the repository to abstract away the persistence implementation.
    public class InMemoryCheeseRepository : ICheeseRepository
    {
        private Dictionary<uint, Cheese> _cheeses = new();
        
        public InMemoryCheeseRepository()
        {
        }

        public Task Add(Cheese cheese)
        {
            _cheeses.Add(cheese.Id, cheese);
            return Task.CompletedTask;
        }

        public Task Delete(uint id)
        {
            if (!_cheeses.ContainsKey(id))
            {
                throw new KeyNotFoundException($"Item with key {id} not found");
            }

            _cheeses.Remove(id);
            return Task.CompletedTask;
        }

        public Task<Cheese> Get(uint id)
        {
            if (!_cheeses.ContainsKey(id))
            {
                throw new KeyNotFoundException($"Item with key {id} not found");
            }

            return Task.FromResult(_cheeses[id]);
        }

        public Task<Cheese> Update(Cheese cheese)
        {
            if (!_cheeses.ContainsKey(cheese.Id))
            {
                throw new KeyNotFoundException($"Item with key {cheese.Id} not found");
            }

            _cheeses[cheese.Id] = cheese;
            return Task.FromResult(cheese);
        }

        public Task<IEnumerable<Cheese>> GetAll() 
            => Task.FromResult(_cheeses.Values.AsEnumerable());
    }
}