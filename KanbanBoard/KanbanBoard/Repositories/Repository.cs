using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Security;
using PetaPoco;

namespace KanbanBoard
{
    public class Repository
    {
        protected Database db;
        private const string BDD_NAME = "Postgres";

        public Repository()
        {
            db = new PetaPoco.Database(BDD_NAME);
        }
    }
}
