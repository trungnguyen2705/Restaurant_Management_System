using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Identity.Client.NativeInterop;
using Restaurant_Management_System.Dal;
using Restaurant_Management_System.Models.Entities;
using Restaurant_Management_System.Models.ViewModels;

namespace Restaurant_Management_System.Dao
{
    public class TableDao
    {
        DatabaseContext db;
        public TableDao()
        {
            db = new DatabaseContext();
        }

        //get table view by id
        public TableView getTableById(int id)
        {
            TableView? table = this.db.Table.Include(t=> t.Area).Include(t => t.TableStatus)
                                            .Where(t => t.Id == id)
                                            .Select(t=> new TableView() { 
                                                                            Id = t.Id,
                                                                            Name = t.Name,
                                                                            NumberOfSeats = t.NumberOfSeats,
                                                                            AreaId = t.AreaId,
                                                                            StatusId = t.TableStatusId,
                                                                            AreaName = t.Area.Name,
                                                                            StatusName = t.TableStatus.Name
                                                                        }).FirstOrDefault();

            return table;
        }

        //update table
        public int updateTable(Table newTable)
        {
            // find table
            Table? table = this.db.Table.Where(t => t.Id == newTable.Id).FirstOrDefault();

            if(table == null)
            {
                return 0;
            }

            // update
            table.Name = newTable.Name;
            table.NumberOfSeats = newTable.NumberOfSeats;
            table.TableStatusId = newTable.TableStatusId;
            table.AreaId = newTable.AreaId;

            return this.db.SaveChanges();
        }



        //get all tables
        public TablePageView GetAllTables(TableSearchViewModel searchModel)
        {
            DatabaseContext db = this.db;
            IQueryable<Table> query = db.Table.Include(t => t.TableStatus).AsNoTracking();

            //search by name
            if (!string.IsNullOrEmpty(searchModel.TableName))
            {
                query = query.Where(t => t.Name.Contains(searchModel.TableName));
            }

            //search by number of seats
            if (searchModel.NumberOfSeats != null)
            {
                query = query.Where(t => t.NumberOfSeats == searchModel.NumberOfSeats.Value);
            }

            //search by status
            if (searchModel.StatusId != null)
            {
                query = query.Where(t => t.TableStatusId == searchModel.StatusId);
            }

            //search by area
            if (searchModel.AreaId != null)
            {
                query = query.Where(t => t.AreaId == searchModel.AreaId);
            }

            //pagination
            int totalTables = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalTables / searchModel.PageSize);
            query = query.Skip((searchModel.PageIndex - 1) * searchModel.PageSize).Take(searchModel.PageSize);


            //order by name
            query = query.OrderBy(t => t.Name);

            //calc total amount
            int totalAmount = 0;


            return new TablePageView
            {
                Tables = query.Select(t => new TableView
                {
                    Id = t.Id,
                    Name = t.Name,
                    NumberOfSeats = t.NumberOfSeats,
                    StatusId = t.TableStatusId,
                    TotalAmount = totalAmount,
                    StatusName = t.TableStatus.Name
                }).ToList(),
                TotalPages = totalPages,
                PageIndex = searchModel.PageIndex,
                PageSize = searchModel.PageSize
            };
        }


        //create table
        public int AddTable(Table table)
        {
            db.Table.Add(table);
            return db.SaveChanges();
        }

        //delete table
        public int deleteTable(int id)
        {
            // find table
            Table? table = this.db.Table.Where(t => t.Id == id).FirstOrDefault();

            if (table == null)
            {
                return 0;
            }

            // delete
            this.db.Table.Remove(table);

            return this.db.SaveChanges();
        }
    }
}
