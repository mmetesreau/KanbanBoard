using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Authentication.Token;
using Nancy.ModelBinding;
using Nancy.Security;

namespace KanbanBoard
{
    public class ApiModule : NancyModule
    {
        private Board board;
        private Users users;
        private ITokenizer tokenizer;

        public ApiModule(Board board, Users users, ITokenizer tokenizer)
            : base("/api")
        {
            this.board = board;
            this.users = users;
            this.tokenizer = tokenizer;

            Get["/tasks"] = GetTasks;
            Post["/tasks"] = PostTask;
            Put["/tasks/{id:int}"] = PutTask;
            Post["/auth"] = PostAuth;
        }

        private Response PostAuth(dynamic p)
        {
            var username = (string)this.Request.Form.Username;
            var password = (string)this.Request.Form.Password;

            var userIdentity = users.GetOneByUserNameAndPassword(username,password);

            if (userIdentity == null)
            {
                return HttpStatusCode.Unauthorized;
            }

            userIdentity.Claims = new List<string>() { userIdentity.Id.ToString() };

            var token = tokenizer.Tokenize(userIdentity, Context);

            return Response.AsJson(new
            {
                Token = token
            });
        }

        private long GetCurrentUserIdFromClaims()
        {
            var user = this.Context.CurrentUser;

            var id = long.Parse(user.Claims.First());

            return id;
        }

        private Response PostTask(dynamic p)
        {
            this.RequiresAuthentication();

            var task = this.Bind<Task>();

            task.Creation = DateTime.Now;
            task.Userid = GetCurrentUserIdFromClaims();

            board.Insert(task);

            return Response.AsJson(task, HttpStatusCode.OK);
        }

        private Response PutTask(dynamic p)
        {
            this.RequiresAuthentication();

            var task = this.Bind<Task>();

            task.Userid = GetCurrentUserIdFromClaims();

            board.Update(task);

            return Response.AsJson(task, HttpStatusCode.OK);
        }

        private Response GetTasks(dynamic p)
        {
            this.RequiresAuthentication();

            var userId = GetCurrentUserIdFromClaims();

            var tasks = board.GetAllByUserId(userId);

            return Response.AsJson(tasks, HttpStatusCode.OK);
        }
    }
}
