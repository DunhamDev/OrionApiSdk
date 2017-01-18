using OrionApiSdk;
using OrionApiSdk.ApiEndpoints.Security;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using OrionApiSdk.Objects.Portfolio;
using OrionApiSdk.Objects.Portfolio.Enums;
using OrionApiSdk.Objects.Security;
using OrionApiSdk.Objects.Trading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleProgram
{
    class Program
    {
        private static AuthToken Token { get; set; }
        private static OrionApi Api { get; set; }

        static void Main(string[] args)
        {
            Token = GetAuthToken();
            Api = new OrionApi(Token);
            GetTransactions();
            Console.ReadKey();
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

        public static UserProfile GetUser()
        {
            return Api.Authorization.User();
        }

        private static List<UserInfoDetails> GetUsers()
        {
            return Api.Security.GetUsers();
        }

        public static UserInfoDetails GetUsers(int id)
        {
            return Api.Security.GetUsers(id);
        }

        public static List<RepresentativeVerbose> GetReps()
        {
            return Api.Portfolio.Representatives.GetVerbose();
        }

        public static List<OrionApiSdk.Objects.Portfolio.Account> GetAccounts()
        {
            return Api.Portfolio.Accounts.Get();
        }

        public static List<RepresentativeSimple> GetSimpleReps()
        {
            return Api.Portfolio.Representatives.GetSimple();
        }

        public static Representative GetRep(int id)
        {
            return Api.Portfolio.Representatives.Get(id);
        }

        public static List<OrionApiSdk.Objects.Portfolio.Account> GetRepAccounts(int id)
        {
            return Api.Portfolio.Representatives.GetAccounts(id);
        }

        public static void GetAccountsVerbose()
        {
            var accts = Api.Portfolio.Accounts.GetAsync(isActive: false).ConfigureAwait(false).GetAwaiter().GetResult();

            foreach (var item in accts)
            {
                Console.WriteLine(item.Id);
            }
            Console.WriteLine("Done");
        }
        public static void GetTransactions()
        {
            int numToRetrieve = 5000;
            int numToSkip = 0;
            while (numToRetrieve != 0)
            {
                Console.WriteLine("Retrieving {0}-{1}...", numToSkip + 1, numToRetrieve + numToSkip);
                var trans = Api.Portfolio.Transactions.GetAsync(top: numToRetrieve, skip: numToSkip).ConfigureAwait(false).GetAwaiter().GetResult();
                Console.WriteLine("Retrieved {0}!", trans.Count);
                numToSkip += trans.Count;
                if (trans.Count < numToRetrieve)
                {
                    numToRetrieve = 0;
                }

                foreach (var t in trans)
                {
                    Console.WriteLine(t.Id);
                }
            }
            Console.WriteLine("Done");
        }

        //public static List<AccountSimple> GetAccountValues(int id)
        //{
        //    return Api.Portfolio.Representatives.GetAccountValues(id, new DateTime(2016, 9, 30));
        //}

        //public static AccountSimple GetAccountValue(int accountId)
        //{
        //    return Api.Portfolio.Accounts.GetValue(accountId);
        //}

        //public static List<BrokerDealer> GetBDs()
        //{
        //    return Api.Portfolio.BrokerDealers.Get();
        //}

        //public static List<AumOverTime> GetAumOverTime(int clientId)
        //{
        //    return Api.Portfolio.Clients.GetAumOverTime(clientId);
        //}

        //public static List<UserInfoDetails> PostUsers()
        //{
        //    OrionApi api = new OrionApi(Token);
        //    return api.SecurityEndpoint.PostUsers(new UserInfoDetails()
        //    {
        //        Profiles = new List<Profile>
        //        {
        //            new Profile
        //            {
        //                Id = 1055186,
        //                IsUserDefault = true,
        //                IsInCurrentDb = true,
        //                LoginEntity = OrionApiSdk.Objects.Enums.LoginEntity.Household,
        //                EntityId = 4,
        //                RoleId = 5,
        //            }
        //        },
        //        Password = "T3sting123!",
        //        UserId = "Dunham.UploadTest",
        //        FirstName = "Upload Test",
        //        LastName = "Dunham",
        //        Email = "billy.wolfington@dunham.com",
        //        IsActive = true,
        //        ActiveDate = DateTime.Now.Date,
        //        InactiveDate = null,
        //        LastLogin = DateTime.Now.Date,
        //        LastPasswordChange = DateTime.Now.Date,
        //        IsReset = false,
        //        MobilePhone = null,
        //        BusinessPhone = null,
        //        BusinessPhoneExtension = null,
        //        Company = null,
        //        JobTitle = null,
        //        EntityName = "Test_Household Test"
        //    });
        //}
    }
}
