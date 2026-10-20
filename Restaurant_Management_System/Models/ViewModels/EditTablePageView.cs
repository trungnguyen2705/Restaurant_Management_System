using Restaurant_Management_System.Models.Entities;

namespace Restaurant_Management_System.Models.ViewModels
{
    public class EditTablePageView
    {
        public TableView TableView { get; set; }
        public List<Area> Areas { get; set; }
        public List<TableStatus> TableStatuses { get; set; }
    }
}
