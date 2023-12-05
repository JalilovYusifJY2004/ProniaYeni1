using System.ComponentModel.DataAnnotations;

namespace ProniaAB104.Models
{
    public class Tag
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Ad daxil ele")]

        public string Name { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
    }
}
