using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard
{
    public class Users : Repository
    {
        private const string QUERY_SELECT_BY_USERNAME_AND_PASSWORD = "SELECT * FROM users where username=@username and password=@password";

        public User GetOneByUserNameAndPassword(string username, string password)
        {
            return db.FirstOrDefault<User>(QUERY_SELECT_BY_USERNAME_AND_PASSWORD, new { username = username, password = password });
        }
    }
}
