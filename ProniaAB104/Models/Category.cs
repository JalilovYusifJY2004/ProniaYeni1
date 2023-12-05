using System.ComponentModel.DataAnnotations;

namespace ProniaAB104.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad daxil ele")]
  
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
