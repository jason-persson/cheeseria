namespace Domain
{
    public class CheesePriceCalculator : ICheesePriceCalculator
    {
        private ICheeseRepository _repository;

        public CheesePriceCalculator(ICheeseRepository repository)
        {
            _repository = repository;
        }
        public async Task<decimal> CalculateCheesePrice(uint id, decimal kgToBuy)
        {
            var cheese = await _repository.Get(id);
            return cheese == null ? 0 : cheese.PricePerKg * kgToBuy;
        }
    }
}