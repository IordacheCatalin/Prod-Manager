namespace Prod_Manger.Models.Domain
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string?Name { get; set; }
        public string?Description { get; set; }
        public string? Category { get; set; }
        public string? SubCategory1 { get; set; }
        public string? SubCategory2 { get; set; }
        public string? SubCategory3 { get; set; }
        public string? SubCategory4 { get; set; }
        public int Buc { get; set; }
        public decimal BuyPriceVAT { get; set; }
        public decimal BuyPriceNoVAT { get; set; }
        public decimal SellPriceVAT { get; set; }
        public decimal SellPriceNoVAT { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
    }
}
