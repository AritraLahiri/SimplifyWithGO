var datatable;

$(document).ready(function () {
    loadDataTable();

});

const loadDataTable = () => {
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
            { data: 'name', "width": "200px" },
            { data: 'description', "width": "200px" },
            { data: 'price', "width": "200px" },
            { data: 'category.name', "width": "200px" },
            {
                data: "id", "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?Id=${data}" class="btn btn-primary mx-2"> Edit </a>
                    <a onClick=DeleteProduct("/admin/product/delete?Id=${data}") class="btn btn-danger mx-2"> Delete </a>
                    </div>
                    `
                }
            }
        ]
    });
}

const DeleteProduct = (url) => {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Are you sure you want to delete this product?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel!",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    datatable.ajax.reload();
                    if (data.success === false) {
                        swalWithBootstrapButtons.fire({
                            icon: "error",
                            title: "Oops...",
                            text: "Something went wrong! Product not deleted."
                        });
                    }
                    else {
                        swalWithBootstrapButtons.fire({
                            title: "Deleted!",
                            text: "Product has been deleted.",
                            icon: "success"
                        });
                    }
                }
            })
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire({
                title: "Cancelled",
                text: "Product is safe :)",
                icon: "error"
            });
        }
    });
}