namespace Restaurant_Management_System.Models.ViewModels
{
    public class TableView
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NumberOfSeats { get; set; }
        public TimeOnly StartTime { get; set; }
        public int TotalAmount { get; set; }
        public int StatusId { get; set; }
        public int AreaId { get; set; }
        public String StatusName { get; set; }
        public String AreaName { get; set; }
    }
}
