namespace Prod_Manger.Models.Domain
{
    public class TotalBuyAndSellModel
    {
        public int Id { get; set; }
        public decimal TotalGeneralBuyVat { get; set; }
        public decimal TotalGeneralBuyNoVAT { get; set; }
        public decimal TotalGeneralSellVAT { get; set; }
        public decimal TotalGeneralSellNoVAT { get; set; }
    } 
}
