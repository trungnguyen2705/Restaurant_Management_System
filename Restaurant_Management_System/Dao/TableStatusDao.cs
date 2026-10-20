using Restaurant_Management_System.Dal;
using Restaurant_Management_System.Models.Entities;

namespace Restaurant_Management_System.Dao
{
    public class TableStatusDao
    {
        private DatabaseContext db;
        public TableStatusDao()
        {
            db = new DatabaseContext();
        }

        public List<TableStatus> GetTableStatuses()
        {
            return this.db.TableStatus.ToList();
        }
    }
}
