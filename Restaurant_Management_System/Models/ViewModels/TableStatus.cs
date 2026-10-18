using System.ComponentModel;

namespace Restaurant_Management_System.Models.ViewModels
{
    public enum TableStatus
    {
        [Description("Available")]
        AVAILABLE,
        [Description("Occupied")]
        OCCUPIED,
        [Description("Dirty")]
        DIRTY,
    }
}
