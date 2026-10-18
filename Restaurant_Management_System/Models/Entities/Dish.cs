namespace Restaurant_Management_System.Models.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String? Description { get; set; } = null;
        public int Price { get; set; }
        public String? Image { get; set; } = null;

        // Foreign key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
