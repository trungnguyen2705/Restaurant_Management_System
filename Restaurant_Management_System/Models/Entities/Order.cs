namespace Restaurant_Management_System.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalAmount { get; set; }
        public int DiscountAmount { get; set; }
        public int FinalAmount { get; set; }

        //foreign keys
        public int PromotionId { get; set; }
        public int CustomerId { get; set; }

        //navigation properties
        public Promotion Promotion { get; set; }
        public Customer Customer { get; set; }
    }
}
