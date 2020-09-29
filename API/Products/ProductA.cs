namespace API.Products
{
    public class ProductA : ICalculationUnit
    {
        public ProductA(int consumption)
        {
            Consumption = consumption;
        }

        public ProductA()
        {
        }

        public string TariffName = "basic electricity tariff";

        public int Consumption { get; set; }

        public decimal AnnualCosts => BaseCost + (Consumption * ConsumptionCost);

        public decimal BaseCost => 5 * 12;

        public decimal ConsumptionCost => 0.22M;
    }
}
