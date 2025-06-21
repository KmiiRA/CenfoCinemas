using DataAccess.CRUD;
using DTOs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager : BaseManager
    {
        /// <summary>
        /// Método para la creación de un usuario
        /// - Valida que el usuario sea mayor de 18 años
        /// - Valida que el código de usuario esté disponible
        /// - Valida que el correo electrónico no esté registrado
        /// - Envía un correo electrónico de bienvenida
        /// </summary>
        public void Create(User user)
        {
            try
            {
                // Validar la edad
                if (IsOver18(user))
                {
                    var uCrud = new UserCrudFactory();

                    // Consultamos en la BD si existe un usuario con ese código
                    var exiSt = uCrud.RetrieveByUserCode<User>(user);

                    if (exiSt == null)
                    {
                        // Consultamos si en la BD existe un usuario con ese email
                        exiSt = uCrud.RetrieveByEmail<User>(user);

                        if (exiSt == null)
                        {
                            uCrud.Create(user);
                            // AHORA SIGUE EL ENVÍO DE CORREO
                        }
                        else
                        {
                            throw new Exception("Este correo electrónico ya se encuentra registrado.");
                        }
                    }
                    else
                    {
                        throw new Exception("El código de usuario no está disponible.");
                    }
                }
                else
                {
                    throw new Exception("Usuario no cumple con la edad mínima.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }

            return age >= 18;
        }
    }
}
