using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard
{
    public class Board : Repository
    {
        private const string TABLE_NAME = "tasks";
        private const string PK_COLUMN = "id";
        private const string QUERY_SELECT_BY_USERID = "SELECT * FROM tasks where userid=@userId";

        public void Insert(Task task)
        {
            db.Insert(TABLE_NAME, PK_COLUMN, true, task);
        }

        public void Update(Task task)
        {
            db.Update(TABLE_NAME, PK_COLUMN, task);
        }

        public object GetAllByUserId(long userId)
        {
            return db.Query<Task>(QUERY_SELECT_BY_USERID, new { userId = userId }).ToList();
        }
    }
}
