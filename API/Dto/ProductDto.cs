namespace API.Dto
{
    public class ProductDto
    {
        /// <summary>
        /// Tariff Name
        /// </summary>
        public string TariffName { get; set; }

        /// <summary>
        /// Annual costs (€/year)
        /// </summary>
        public decimal AnnualCosts { get; set; }
    }
}
