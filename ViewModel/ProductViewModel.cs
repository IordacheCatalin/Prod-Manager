namespace Prod_Manger.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Category { get; set; }
        public int Buc { get; set; }
        public decimal BuyPriceVAT { get; set; }
        public decimal BuyPriceNoVAT { get; set; }
        public decimal SellPriceVAT { get; set; }
        public decimal SellPriceNoVAT { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
    }
}
