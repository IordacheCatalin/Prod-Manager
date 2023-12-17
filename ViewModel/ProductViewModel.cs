namespace Prod_Manger.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? SubSubCategory { get; set; }
        public string? SubSubSubCategory { get; set; }
        public string? SubSubSubSubCategory { get; set; }
        public int Buc { get; set; }
        public decimal BuyPriceVAT { get; set; }
        public decimal BuyPriceNoVAT { get; set; }
        public decimal SellPriceVAT { get; set; }
        public decimal SellPriceNoVAT { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }

        public decimal TotalBuyPriceVAT { get; set; }
        public decimal TotalBuyPriceNoVAT { get; set; }
        public decimal TotalSellPriceVAT { get; set; }
        public decimal TotalSellPriceNoVAT { get; set; }
    }
}
