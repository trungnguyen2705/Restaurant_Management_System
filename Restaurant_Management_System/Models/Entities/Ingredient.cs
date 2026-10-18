namespace Restaurant_Management_System.Models.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int ImportPrice { get; set; }
        public float Quantity { get; set; }
        public String Unit { get; set; }
        public int SupplierId { get; set; }

        //foreign key
        public Supplier Supplier { get; set; }
    }
}
