namespace Order.Host.Model.Dto
{
    public class BasketDto
    {
        public int BasketId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<BasketItemDto> Items { get; set; }
    }
}