function showTableDetail(){
    //display table detail
    console.log("aaaaaa");
    const tableDetailForm = document.getElementById('table-detail-container');
    tableDetailForm.style.display = "block";

    // get data
    const id = 2;
    fetch(`/Table/Detail?id=${id}`, { method: "GET" })
        .then(response => response.json())
        .then(result => {
            console.log(result);
            const name = document.getElementById("table-detail-name");
            const area = document.getElementById("table-detail-area");
            const status = document.getElementById("table-detail-status");
            const numOfSeat = document.getElementById("table-detail-numOfSeat");
            const startTime = "10";

            name.textContent = result.tableView?.name || '_';
            area.textContent = result.tableView?.areaName || '_';
            numOfSeat.textContent = result.tableView?.numberOfSeats || '_';
            status.textContent = result.tableView?.statusName || '_';
        })
        .catch(error => {
            console.error("Lỗi khi gọi API:", error);
        });
}

function createTableIcon(){
    //get data
    const dataElement = document.getElementById('app-data');
    if (!dataElement){
        return;
    }

    const data =JSON.parse(dataElement.getAttribute('data-model'));

    //get icon temp
    const tableIconTemplate = document.querySelector(".table-template");
    if (!tableIconTemplate){
        console.error("Không tìm thấy phần tử .table-template");
        return;
    };

    console.log(data);

    for(let i=0;i<data.Tables.length;i++){
        // clone icon
        const newIcon = tableIconTemplate.cloneNode(true);
        newIcon.style.display = "flex";
        
        //set attributes
        const tableData = data.Tables[i];
        if (tableData.StatusId === 1) {
            newIcon.classList.add('table-available');
        } else if (tableData.StatusId === 2) {
            newIcon.classList.add('table-occupied');
        } else if (tableData.StatusId === 3) {
            newIcon.classList.add('table-dirty');
        } else {
            console.log(tableData.StatusId);
            newIcon.classList.add('table-available');
        }

        newIcon.querySelector("h5").querySelector(".table-name").textContent = tableData.Name;
        newIcon.querySelector("h5").querySelector("div").textContent = tableData.StatusName;

        newIcon.querySelector("label").textContent = `Seats: ${tableData.NumberOfSeats}`;

        newIcon.querySelector('.status-contain').querySelector('.status-content').textContent = tableData.StatusName;
        if (tableData.TotalAmount > 0) {
            newIcon.querySelector('.status-contain').querySelector('.total-amount').textContent = `${tableData.TotalAmount / 1000}K`;
        } else {
            newIcon.querySelector('.status-contain').querySelector('.total-amount').style.display = "none";
        }

        // create
        tableIconTemplate.parentNode.appendChild(newIcon);

        // add event
        newIcon.addEventListener("click", function(){
            // show table detail
            const tableDetailForm = document.getElementById('table-detail-container');
            tableDetailForm.style.display = "block";

            // config
            showTableDetail();

            // addevent
            const updateButton = document.getElementById('update-table-button');
            updateButton.addEventListener("click", function () {
                window.location.href = `/Table/Edit?id=${tableData.Id}`;
            });

            const payButton = document.getElementById('pay-button');
            payButton.addEventListener("click", function () {
            });

            const addDishButton = document.getElementById('add-dish-button');
            addDishButton.addEventListener("click", function () {
                window.location.href = '/Dish/Order';
            });
        });
        
    }
}


document.addEventListener('DOMContentLoaded', function() {
    createTableIcon();
});