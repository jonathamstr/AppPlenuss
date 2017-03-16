using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class UserService
    {
        static List<User> usuarios;

        public static User GetUser(int identifier)
        {
            if(usuarios == null)
            {
                usuarios = new List<User>
                {
                    new User(1,"Juan","Enginer"),
                    new User(2,"Carlos","Developer"),
                    new User(3,"Alonso","Coder"),
                    new User(4,"Nuria","Adminstrador"),
                    new User(5,"Sergio","Alguien"),
                    new User(6,"Maria","Profesora"),
                    new User(7,"Jonathan","Progammer")

                };
            }
            return usuarios.Single(user => user.Id == identifier);
        }
    }
}
