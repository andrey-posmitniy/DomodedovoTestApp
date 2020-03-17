$(document).ready(function () {
    console.log("ready!");


    //$("#grid").kendoGrid({
    //    dataSource: {
    //        type: "odata",
    //        transport: {
    //            read: "https://demos.telerik.com/kendo-ui/service/Northwind.svc/Customers"
    //        },
    //        pageSize: 20
    //    },
    //    height: 550,
    //    groupable: true,
    //    sortable: true,
    //    pageable: {
    //        refresh: true,
    //        pageSizes: true,
    //        buttonCount: 5
    //    },
    //    columns: [{
    //        template: "<div class='customer-photo'" +
    //        "style='background-image: url(../content/web/Customers/#:data.CustomerID#.jpg);'></div>" +
    //        "<div class='customer-name'>#: ContactName #</div>",
    //        field: "ContactName",
    //        title: "Contact Name",
    //        width: 240
    //    }, {
    //        field: "ContactTitle",
    //        title: "Contact Title"
    //    }, {
    //        field: "CompanyName",
    //        title: "Company Name"
    //    }, {
    //        field: "Country",
    //        width: 150
    //    }]
    //});

    //var crudServiceBaseUrl = "https://demos.telerik.com/kendo-ui/service";
    var dataSource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: usersODataUrl,
                dataType: "json"
            }
        },
        pageSize: 10,
        serverPaging: true,
        serverSorting: true,
        serverFiltering: true,
        schema: {
            model: {
                id: "UserId",
                fields: {
                    FullName: { type: "string" },
                    DateOfBirth: { type: "date" },
                    Email: { type: "string" },
                    Password: { type: "string" },
                    PictureThumbnail: { type: "string" }
                }
            },
            data: function(data) {
                return data.value;
            },
            total: function(data) {
                return data['odata.count'];
            }
        }
    });

    $("#grid").kendoGrid({
        dataSource: dataSource,
        height: 500,
        sortable: true,
        scrollable: {
            endless: true
        },
        pageable: {
            numeric: false,
            previousNext: false
        },
        filterable: true,
        columns: [
            {
                template: "<div class='user-thumbnail' style='background-image: url(#:data.PictureThumbnail#);'></div>",
                field: "PictureThumbnail",
                title: " ",
                width: 63,
                sortable: false,
                filterable: false
            },
            {
                template: "<a href='#:userCardUrl#/#:data.UserId#'>#:data.FullName#</a>",
                field: "FullName",
                title: "ФИО"
            },
            {
                field: "DateOfBirth",
                title: "Дата рождения",
                width: 150,
                format: "{0: yyyy-MM-dd}"
            },
            {
                field: "Email",
                title: "Email",
                width: 250
            },
            {
                field: "Password",
                title: "Пароль",
                width: 150
            }
        ]
    });

});

