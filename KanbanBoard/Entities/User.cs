using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard
{

    public class User : IUserIdentity
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [PetaPoco.Ignore]
        public IEnumerable<string> Claims { get; set; }
    }
}
