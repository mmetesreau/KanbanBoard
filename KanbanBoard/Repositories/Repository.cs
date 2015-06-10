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
        private const string PROVIDER_NAME = "Npgsql";
        private const string CS_ENV = "CS";

        public Repository()
        {
            string cs = Environment.GetEnvironmentVariable(CS_ENV);
            db = new PetaPoco.Database(cs, PROVIDER_NAME);
        }
    }
}
