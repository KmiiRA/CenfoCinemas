
using DataAccess.CRUD;
using DataAccess.DAO;
using DTOs;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Seleccione la opción deseada:");
        Console.WriteLine("1. Crear usuario");
        Console.WriteLine("2. Consultar usuarios");
        Console.WriteLine("3. Eliminar usuario");
        Console.WriteLine("4. Crear película");
        Console.WriteLine("5. Consultar películas");
        Console.WriteLine("6. Eliminar películas");
        Console.WriteLine("7. Actualizar películas");
        Console.WriteLine("8. Eliminar películas");

        var option = Int32.Parse(Console.ReadLine());
        var sqlOperation = new SqlOperation();

        switch (option)
        {
            case 1:
                Console.WriteLine("Digite el código de usuario:");
                var userCode = Console.ReadLine();

                Console.WriteLine("Digite el nombre:");
                var name = Console.ReadLine();

                Console.WriteLine("Digite el email:");
                var email = Console.ReadLine();

                Console.WriteLine("Digite el password:");
                var password = Console.ReadLine();

                var status = "AC";

                Console.WriteLine("Digite la fecha de nacimiento:");
                var bdate = DateTime.Parse(Console.ReadLine());

                // Creamos el objeto del usuario a partir de los valores capturados en consola
                var user = new User()
                {
                    UserCode = userCode,
                    Name = name,
                    Email = email,
                    Password = password,
                    Status = status,
                    BirthDate = bdate
                };

                var uCrud = new UserCrudFactory();
                uCrud.Create(user);
                break;

            case 2:
                uCrud = new UserCrudFactory();
                var lstUsers = uCrud.RetrieveAll<User>();
                foreach (var u in lstUsers)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(u));
                }
                break;

            case 4:
                Console.WriteLine("Digite el título:");
                var title = Console.ReadLine();

                Console.WriteLine("Digite la descripción:");
                var desc = Console.ReadLine();

                Console.WriteLine("Digite la fecha de lanzamiento:");
                var rdate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Digite el género de la película:");
                var genre = Console.ReadLine();

                Console.WriteLine("Digite el director:");
                var director = Console.ReadLine();

                sqlOperation.ProcedureName = "CRE_MOVIE_PR";
                sqlOperation.AddStringParameter("P_Title", title);
                sqlOperation.AddStringParameter("P_Description", desc);
                sqlOperation.AddDateTimeParam("P_ReleaseDate", rdate);
                sqlOperation.AddStringParameter("P_Genre", genre);
                sqlOperation.AddStringParameter("P_Director", director);

                // Ejecución del procedure
                var sqlDao = SqlDao.GetInstance();
                sqlDao.ExecuteProcedure(sqlOperation);
                break;
        }
    }
}