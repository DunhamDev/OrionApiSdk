﻿using OrionApiSdk;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using OrionApiSdk.Objects.Portfolio;
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
            var reps = GetReps();
            var simpleReps = GetSimpleReps();
            var rep = GetRep(reps[0].Id);
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
            OrionApi api = new OrionApi(Token);
            return api.AuthorizationEndpoint.User();
        }

        private static List<UserInfoDetails> GetUsers()
        {
            OrionApi api = new OrionApi(Token);
            return api.SecurityEndpoint.GetUsers();
        }

        public static UserInfoDetails GetUsers(int id)
        {
            OrionApi api = new OrionApi(Token);
            return api.SecurityEndpoint.GetUsers(id);
        }

        public static List<Representative> GetReps()
        {
            OrionApi api = new OrionApi(Token);
            return api.PortolioEndpoint.GetRepresentatives();
        }

        public static List<RepresentativeSimple> GetSimpleReps()
        {
            OrionApi api = new OrionApi(Token);
            return api.PortolioEndpoint.GetRepresentativesSimple();
        }

        public static Representative GetRep(int id)
        {
            OrionApi api = new OrionApi(Token);
            return api.PortolioEndpoint.GetRepresentatives(id);
        }

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
