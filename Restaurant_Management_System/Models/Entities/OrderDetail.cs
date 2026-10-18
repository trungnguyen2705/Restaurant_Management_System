namespace Restaurant_Management_System.Models.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int OrderId { get; set; }
        public float Quantity { get; set; }
        public int Price { get; set; }

        //navigation properties
        public Dish Dish { get; set; }
        public Order Order { get; set; }
    }
}
