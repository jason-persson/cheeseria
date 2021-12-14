namespace Domain
{
    public interface ICheesePriceCalculator
    {
        Task<decimal> CalculateCheesePrice(uint id, decimal kgToBuy);
    }
}