namespace Restaurant_Management_System.Models.Entities
{
    public class DishIngredient
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Dish Dish { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
