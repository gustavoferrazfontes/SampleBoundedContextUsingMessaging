namespace WebApi.Models
{
    public class OrderPlaced
    {
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public int ItemsQuantity { get; set; }
    }
}