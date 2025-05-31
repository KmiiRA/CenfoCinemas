using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    /*
     * Clase u objeto que se encarga de la comunicacion con la base de datos
     * solo ejecuta Store Procedures
     * 
     * Esta clase implementa el Patrón de Singleton
     * para asignar la existencia de una única instancia de este objeto
     */
    public class SqlDao
    {

        //Paso 1: Crear una instancia privada de la misma clase
        private static SqlDao instance;

        private string connectionString;

        //Paso 2: Redefinir el constructor defaul y convertirlo en privado
        private SqlDao()
        {

            connectionString = string.Empty;

        }

        //Paso 3: Definir el método que expone la instancia
        public static SqlDao getInstance()
        {
            if(instance == null)
            {
                instance = new SqlDao();
            }
            return instance;

        }

        //Método para la ejecución de SP sin retorno
        public void ExecuteProcedure(SqlOperation operation)
        {
            //Conectarse a la BD
            //Ejecutar SP

        }


        //Método para la ejecucion de SP con retorno de data
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation operation)
        {
            //Conectarse a la BD
            //Ejecutar SP
            //Capturar el resultado
            //Convertirlo en DTOs

            var list = new List<Dictionary<string, object>>();

            return list;

        }

    }
}
