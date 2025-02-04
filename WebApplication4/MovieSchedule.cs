namespace WebApplication4
{
    public class MovieSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<DateTime> Sessions { get; set; } = new();
    }
}
