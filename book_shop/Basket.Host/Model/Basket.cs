namespace Basket.Host.Model
{
    public class Basket
    {
        public int BasketId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
