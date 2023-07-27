using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Model.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
