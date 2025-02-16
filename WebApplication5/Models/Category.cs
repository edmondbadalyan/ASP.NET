namespace WebApplication5.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerCategory> CustomerCategories { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
    }
}
