namespace EcommerceDiscountProject.Models
{
    public class DiscountResponse
    {
        public string ProductName { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal CategoryDiscount { get; set; }
        public decimal CustomerDiscount { get; set; }
        public decimal QuantityDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
