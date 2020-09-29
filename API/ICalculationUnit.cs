namespace API
{
    public interface ICalculationUnit
    {
        int Consumption { get; set; }
        decimal AnnualCosts { get; }
        decimal BaseCost { get; }
        decimal ConsumptionCost { get; }
    }
}
