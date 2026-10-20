using Restaurant_Management_System.Models.Entities;

namespace Restaurant_Management_System.Models.ViewModels
{
    public class TableDetailView
    {
        public TableView TableView { get; set; }
        List<Dish> Dishes { get; set; }
    }
}
