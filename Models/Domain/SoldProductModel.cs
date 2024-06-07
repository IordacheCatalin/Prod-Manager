using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prod_Manger.Models.Domain
{
    public class SoldProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int Buc { get; set; }
        public decimal BuyPriceVAT { get; set; }
        public decimal BuyPriceNoVAT { get; set; }
        public decimal SellPriceVAT { get; set; }
        public decimal SellPriceNoVAT { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public string? InvoiceManagement {  get; set; }
        public string? InvoiceNumber { get; set; }
    }
}
