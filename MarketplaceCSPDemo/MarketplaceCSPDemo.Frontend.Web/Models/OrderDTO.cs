namespace MarketplaceCSPDemo.Frontend.Web.Models
{
    public class OrderDTO
    {
        public string? ReferenceCustomerId { get; set; }
        public string? OfferId { get; set; }
        public int Quantity { get; set; }
        public string? BillingCycle { get; set; }
        public string? StatusMessage { get; set; }
    }
}
