using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects
{
    internal class UserCredentials
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Username, Password)));
        }
    }
}
