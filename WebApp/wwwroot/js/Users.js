//JS que maneja todo el comportamiento de la vista de usuarios

//Definir una clase JS, usando prototype
function UsersViewController() {
    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Método constructor
    this.InitView = function () {
        console.log("User init view ==> ok");
        this.LoadTable();

        //Asociar el evento al botón
        $("#btnCreate").click(function () {
            var vc = new UsersViewController();
            vc.Create();
        });

        $("#btnUpdate").click(function () {
            var vc = new UsersViewController();
            vc.Update();
        });

        $("#btnDelete").click(function () {
            var vc = new UsersViewController();
            vc.Delete();
        });
    };
    //Método para la carga de una tabla
    this.LoadTable = function () {

        //URL del API a invocar
        //https://localhost:7226/api/User/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
        {
            "userCode": "crojas",
            "name": "Camila",
            "email": "crojas@ucenfotec.ac.cr",
            "password": "Cenfotec123!",
            "birthDate": "2025-06-12T18:35:44.657",
            "status": "AC",
            "id": 1,
            "created": "2025-06-11T06:36:01.783",
            "updated": "0001-01-01T00:00:00"
        }
    
        <tr>
            <th>Id</th>
            <th>User code</th>
            <th>Name</th>
            <th>Email</th>
            <th>Birth Date</th>
            <th>Status</th>
        </tr>
        */
    };
    var columns = [];
    columns[0] = { 'data': 'id' };
    columns[1] = { 'data': 'userCode' };
    columns[2] = { 'data': 'name' };
    columns[3] = { 'data': 'email' };
    columns[4] = { 'data': 'birthDate' };
    columns[5] = { 'data': 'status' };

    //Invocamos a datatables para convertir la tabla simple html en una tabla más robusta
    $('#tblUsers').dataTable({
        "ajax": {
            "url": urlService,
            "dataSrc": ""
        },
        columns: columns
    });

    //Asignar eventos de carga de datos o binding según el click en la tabla
    $('#tblUsers tbody').on('click', 'tr', function () {
    });

    this.Create = function () {
        var userDTO = {};
        //Atributos con valores default, que son controlados por el API
        userDTO.id = 0;
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        //Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPassword').val();

        /Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, userDTO, function () {
            //Recarga de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        });
    };

    this.Update = function () {
        var userDTO = {};
        // Atributos con valores default, que son controlados por el API
        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, userDTO, function () {
            // Recarga de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        });
    };

    this.Delete = function () {
        var userDTO = {};
        // Atributos con valores default, que son controlados por el API
        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, userDTO, function () {
            // Recarga de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        });
    };

    $(document).ready(function () {
        var vc = new UsersViewController();
        vc.InitView();
    });

}
