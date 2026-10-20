using System.ComponentModel;

namespace Restaurant_Management_System.Models.ViewModels
{
    public enum TableStatusEnum
    {
        [Description("Available")]
        AVAILABLE,
        [Description("Occupied")]
        OCCUPIED,
        [Description("Dirty")]
        DIRTY,
    }
}
