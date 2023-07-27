using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CategoryName { get; set;}
        [Required]
        public string ImageUrl { get; set;} 
    }
}
