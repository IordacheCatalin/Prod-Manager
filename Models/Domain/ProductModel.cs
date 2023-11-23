namespace Prod_Manger.Models.Domain
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Buc { get; set; }
        public decimal BuyPriceVAT { get; set; }
        public decimal BuyPriceNoVAT { get; set; }
        public decimal SellPriceVAT { get; set; }
        public decimal SellPriceNoVAT { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
    }
}
