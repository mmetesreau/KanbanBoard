using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard
{
    public class Task
    {
        public enum TaskStatus
        {
            TODO,
            DOING,
            DONE,
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("userid")]
        public long Userid { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("creation")]
        public DateTime Creation { get; set; }
        [Column("status")]
        public TaskStatus Status { get; set; }
    }
}
