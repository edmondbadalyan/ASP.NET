namespace WebApplication5.Models
{
    public class CustomerCategory
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
