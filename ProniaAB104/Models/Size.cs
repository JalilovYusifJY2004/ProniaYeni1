using System.ComponentModel.DataAnnotations;

namespace ProniaAB104.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad daxil ele")]
    
        public string Name { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }
    }
}
