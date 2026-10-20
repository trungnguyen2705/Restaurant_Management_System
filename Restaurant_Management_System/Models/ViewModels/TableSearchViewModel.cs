namespace Restaurant_Management_System.Models.ViewModels
{
    public class TableSearchViewModel
    {
        public String? TableName { get; set; } = null;
        public int? NumberOfSeats { get; set; } = null;
        public int? StatusId { get; set; } = null;
        public int? AreaId { get; set; } = null;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 15;
    }
}
