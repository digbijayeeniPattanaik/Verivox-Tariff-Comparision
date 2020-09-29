using System;

namespace API.Products
{
    public class ProductB : ICalculationUnit
    {
        public ProductB(int consumption)
        {
            Consumption = consumption;
        }

        public ProductB()
        {
        }

        public string TariffName = "Packaged tariff";

        public int Consumption { get; set; }

        public decimal AnnualCosts => Consumption <= 4000 ? BaseCost : BaseCost + Math.Abs(Consumption - 4000) * ConsumptionCost;

        public decimal BaseCost => 800;

        public decimal ConsumptionCost => 0.30M;
    }
}
