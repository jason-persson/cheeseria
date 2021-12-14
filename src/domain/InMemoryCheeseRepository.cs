﻿namespace Domain
{
    public class InMemoryCheeseRepository : ICheeseRepository
    {
        private Dictionary<int, Cheese> _cheeses;
        
        public InMemoryCheeseRepository()
        {
            _cheeses = new Dictionary<int, Cheese> { { 1, new Cheese(1, "Cheddar") } };
        }

        public Task<IEnumerable<Cheese>> GetCheeses() 
            => Task.FromResult(_cheeses.Values.AsEnumerable());
    }
}