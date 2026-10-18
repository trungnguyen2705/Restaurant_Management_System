namespace Restaurant_Management_System.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public DateOnly Dob { get; set; }
        public int Points { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
