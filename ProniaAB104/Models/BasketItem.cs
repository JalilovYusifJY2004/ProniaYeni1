namespace ProniaAB104.Models
{
    public class BasketItem
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set;}
        public int Count { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

     
    }
    
}
