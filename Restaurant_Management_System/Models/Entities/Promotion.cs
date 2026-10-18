namespace Restaurant_Management_System.Models.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String? Code { get; set; } = null;
        public int? MaxUsage { get; set; } = null;
    }
}
