
$(document).ready(function () {
    loadDataTable();

});

const loadDataTable = () => {
    debugger;
    datatable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            {
                data: 'imageUrl',

                "render": function (data) {
                    return ` 
                    <image src = ${data} class="img-thumbnail w-auto h-25 " style="border-radius:15px;height:20px" ></image
                  
                    `
                },
                "width": "250px"
            },
            { data: 'name' ,"width":"200px" },
            { data: 'description' , "width":"200px" },
            { data: 'price', "width":"200px" },
            { data: 'category.name', "width":"200px" },
            {
                data: "id", "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?Id=${data}" class="btn btn-primary mx-2"> Edit </a>
                    <a href="/admin/product/delete?Id=${data}" class="btn btn-danger mx-2"> Delete </a>
                    </div>
                    `
                }}
        ]
    });
}