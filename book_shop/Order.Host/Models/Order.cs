using System.ComponentModel.DataAnnotations.Schema;

namespace Order.Host.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("BasketId")]
        public int BasketId { get; set; }
        public string UserId { get; set; }
        public int Price { get; set; }
    }
}
