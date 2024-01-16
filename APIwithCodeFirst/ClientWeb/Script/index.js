$(document).ready(function () {
    getEmployee();
    $("#btnUpdateEmp").click(function () {
        var id = $("#txtId").val();
        if (id != '') { updateEmployee(id); }
    });
});
function createEmployee() {
    url1 = "/api/Employee";
    var employee = {};
    //alert("Hi");
    if ($('#txtFirstName').val() === '' || $('#txtLastName').val() === '' || $('#txtGender').val() === '' || $('#txtCity').val() === '') {
        alert("Please fill data proper..");
    }
    else {
        employee.FirstName = $('#txtFirstName').val();
        employee.LastName = $('#txtLastName').val();
        employee.Gender = $('#txtGender').val();
        employee.City = $('#txtCity').val();

        if (employee) {
            $.ajax({
                url: url1,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(employee),
                type: "Post",
                success: function (result) {
                    location.reload();
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }
    }
}

function getEmployee() {
    url = "/api/Employee";
    dataTable = $('#tblEmployee').DataTable({
        "ajax": { url: url, type: "Get" },
        "columns": [
            { data: 'FirstName', "width": "20%" },
            { data: 'LastName', "width": "20%" },
            { data: 'Gender', "width": "15%" },
            { data: 'City', "width": "15%" },
            {
                data: 'Id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a class="btn btn-primary mx-2" onClick=editEmployee('/api/Employee/${data}')> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a onClick=deleteEmployee('/api/Employee/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "30%"
            }
        ]
    });
}
function deleteEmployee(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}

function editEmployee(url) {
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            if (result) {
                $('#txtId').val(result.Id);
                $('#txtFirstName').val(result.FirstName);
                $('#txtLastName').val(result.LastName);
                $('#txtGender').val(result.Gender);
                $('#txtCity').val(result.City);
            }
            $("#btnCreateEmp").prop('disabled', true);
            $("#btnUpdateEmp").prop('disabled', false);
        },
        error: function (msg) {
            alert(msg);
        }
    });

}
function updateEmployee(id) {
    url = "/api/Employee/" + id;
    var employee = {};
   
    employee.FirstName = $('#txtFirstName').val();
    employee.LastName = $('#txtLastName').val();
    employee.Gender = $('#txtGender').val();
    employee.City = $('#txtCity').val();

    if (employee) {
        $.ajax({
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(employee),
            type: "Put",
            success: function (result) {
                location.reload();
            },
            error: function (msg) {
                alert(msg);
            }
        });
    }

}