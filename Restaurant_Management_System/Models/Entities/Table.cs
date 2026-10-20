using Restaurant_Management_System.Models.ViewModels;

namespace Restaurant_Management_System.Models.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int TableStatusId { get; set; }
        public int AreaId { get; set; }

        public Area Area { get; set; }
        public TableStatus TableStatus { get; set; }
    }
}
