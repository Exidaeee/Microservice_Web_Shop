namespace Order.Host.Model.Dto
{
    public class BasketItemDto
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
}
