using Restaurant_Management_System.Dal;
using Restaurant_Management_System.Models.Entities;

namespace Restaurant_Management_System.Dao
{
    public class AreaDao
    {
        private DatabaseContext db;
        public AreaDao()
        {
            db = new DatabaseContext();
        }

        // get all area
        public List<Area> getAreas()
        {
            return this.db.Area.ToList();
        }
    }
}
