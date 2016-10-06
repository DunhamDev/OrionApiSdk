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
        static void Main(string[] args)
        {
            AuthToken token = GetAuthToken();
            var user = GetUser(token);
            var userList = GetUsers(token);
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

        public static User GetUser(AuthToken token)
        {
            OrionApi api = new OrionApi(token);
            return api.AuthorizationEndpoint.User();
        }

        private static List<SimpleUser> GetUsers(AuthToken token)
        {
            OrionApi api = new OrionApi(token);
            return api.SecurityEndpoint.Users();
        }
    }
}
