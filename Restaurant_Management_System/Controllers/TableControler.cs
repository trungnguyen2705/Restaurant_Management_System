using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant_Management_System.Dao;
using Restaurant_Management_System.Models.Entities;
using Restaurant_Management_System.Models.ViewModels;

namespace Restaurant_Management_System.Controllers
{
    [Route("Table")]
    public class TableControler: Controller
    {
        [HttpGet("List")]
        public IActionResult Index(String? name, int? area, int? numOfSeat, int? status, int? page)
        {
            //create filter
            TableSearchViewModel searchModel = new TableSearchViewModel();

            if (!string.IsNullOrEmpty(name))
            {
                searchModel.TableName = name;
            }

            if (area.HasValue && area.Value > 0)
            {
                searchModel.AreaId = area;
            }

            if (numOfSeat.HasValue && numOfSeat.Value > 0)
            {
                searchModel.NumberOfSeats = numOfSeat;
            }

            if (page.HasValue && page.Value > 0)
            {
                searchModel.PageIndex = (int)page;
            }

            if (status.HasValue && status.Value > 0)
            {
                searchModel.StatusId = status;
            }

            // add tale into db
            TablePageView tablePageView = new TableDao().GetAllTables(searchModel);
            if (tablePageView == null)
            {
                tablePageView = new TablePageView();
            }
            //display
            return View("~/Areas/Admin/Views/TableLayout.cshtml", tablePageView);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            // get area list
            List<Area> areas = new AreaDao().getAreas();
            // get status list
            List<TableStatus> tableStatuses = new TableStatusDao().GetTableStatuses();

            //get object
            CreateTablePageView createTablePageView = new CreateTablePageView();
            createTablePageView.Areas = areas;
            createTablePageView.TableStatuses = tableStatuses;
            return View("~/Areas/Admin/Views/CreateTable.cshtml", createTablePageView);
        }

        [HttpPost("Create")]
        public IActionResult Create(String name, int area, int numOfSeat, int status)
        {
            Console.WriteLine(name + "-" + area + "-" + numOfSeat + "-" + status);
            //create filter
            if(string.IsNullOrEmpty(name))
            {
                return BadRequest("Name is required");
            }

            Table table = new Table();
            table.Name = name;
            table.AreaId = area;
            table.NumberOfSeats = numOfSeat;
            table.TableStatusId = status;

            // add tale into db
            int result = new TableDao().AddTable(table);

            //redirect to list page
            if (result > 0)
            {
                Console.WriteLine("Add table success");
                return RedirectToAction("List", "Table");
            }
            else
            {
                return BadRequest("Add table failed");
            }
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            //get table
            TableView table = new TableDao().getTableById(id);
            // get area list
            List<Area> areas = new AreaDao().getAreas();
            // get status list
            List<TableStatus> tableStatuses = new TableStatusDao().GetTableStatuses();

            //get object
            EditTablePageView editTablePageView = new EditTablePageView();
            editTablePageView.Areas = areas;
            editTablePageView.TableStatuses = tableStatuses;
            editTablePageView.TableView = table;


            if(table != null)
            {
                return View("~/Areas/Admin/Views/EditTable.cshtml", editTablePageView);
            }

            return View("~/Areas/Admin/Views/EditTable.cshtml");
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, String name, int numOfSeat, int statusId, int areaId)
        {
            Console.WriteLine(areaId);
            // create new Table
            Table table = new Table();
            table.Id = id;
            table.Name = name;
            table.NumberOfSeats = numOfSeat;
            table.TableStatusId = statusId;
            table.AreaId = areaId;

            //update
            int result = new TableDao().updateTable(table);

            return RedirectToAction("List", "Table");
        }


        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            int result = new TableDao().deleteTable(id);
            return RedirectToAction("List", "Table");
        }

        [HttpGet("Detail")]
        public IActionResult Detail(int id)
        {
            // get curent order

            // get table info
            TableView table = new TableDao().getTableById(id);

            TableDetailView tableDetailView = new TableDetailView();
            tableDetailView.TableView = table;
            return Ok(tableDetailView);
        }
    }
}
