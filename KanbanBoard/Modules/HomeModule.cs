using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/status"] = _ => "I am alive";
        }
    }
}
