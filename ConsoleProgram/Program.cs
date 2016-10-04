using OrionApiSdk;
using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthToken token = GetAuthToken();
            User user = GetUser(token);
        }

        private static AuthToken GetAuthToken()
        {
            OrionApi api = new OrionApi();
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            Console.WriteLine("*** WARNING: Your password WILL be visible ***");
            string password = Console.ReadLine();

            return api.AuthenticateUser(username, password);
        }

        private static User GetUser(AuthToken token)
        {
            OrionApi api = new OrionApi(token);
            return api.Authorization.User();
        }
    }
}
