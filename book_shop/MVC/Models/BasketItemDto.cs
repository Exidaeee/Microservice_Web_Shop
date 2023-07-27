namespace MVC.Models
{
    public class BasketItemDto
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
