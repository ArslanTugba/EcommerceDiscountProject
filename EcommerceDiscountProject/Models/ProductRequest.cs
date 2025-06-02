namespace EcommerceDiscountProject.Models
{
    public class ProductRequest
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public string CustomerType { get; set; }
    }
}
