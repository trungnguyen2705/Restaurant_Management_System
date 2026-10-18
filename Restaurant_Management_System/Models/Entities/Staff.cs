namespace Restaurant_Management_System.Models.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public DateOnly Dob { get; set; }
        public int Salary { get; set; }
        public String? Image { get; set; } = null;

        public int AccountId { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public Account Account { get; set; }
    }
}
