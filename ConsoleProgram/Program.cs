using OrionApiSdk;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using OrionApiSdk.Objects.Security;
using System;
using System.Collections.Generic;

namespace ConsoleProgram
{
    class Program
    {
        private static AuthToken Token { get; set; }

        static void Main(string[] args)
        {
            Token = GetAuthToken();
            var user = GetUser();
            var userList = GetUsers();
            var completeUser = GetUsers(Int32.Parse(user.UserId));
        }

        private static AuthToken GetAuthToken()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            Console.WriteLine("*** WARNING: Your password WILL be visible ***");
            string password = Console.ReadLine();

            return OrionApi.GetUserAuthToken(username, password);
        }

        public static User GetUser()
        {
            OrionApi api = new OrionApi(Token);
            return api.AuthorizationEndpoint.User();
        }

        private static List<SimpleUser> GetUsers()
        {
            OrionApi api = new OrionApi(Token);
            return api.SecurityEndpoint.Users();
        }

        public static CompleteUser GetUsers(int id)
        {
            OrionApi api = new OrionApi(Token);
            return api.SecurityEndpoint.Users(id);
        }
    }
}
