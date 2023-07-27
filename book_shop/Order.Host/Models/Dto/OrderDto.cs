namespace Order.Host.Models.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public  int BasketId { get; set; }
        public string UserId { get; set; }
        public int Price { get; set; }
    }
}
