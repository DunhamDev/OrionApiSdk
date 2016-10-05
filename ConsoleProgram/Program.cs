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
            var result = GetUsers(token);
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

        private static List<User> GetUsers(AuthToken token)
        {
            OrionApi api = new OrionApi(token);
            return api.SecurityEndpoint.Users();
        }
    }
}
