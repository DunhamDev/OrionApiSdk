using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class PortfolioEndpoint : ApiEndpointBase
    {
        public PortfolioEndpoint(AuthToken token) : base("Portfolio", token)
        {
        }

        private AccountsMethods _accountMethods;
        public AccountsMethods Accounts
        {
            get
            {
                return _accountMethods ?? (_accountMethods = new AccountsMethods(AuthToken));
            }
        }

        private BrokerDealersMethods _bdMethods;
        public BrokerDealersMethods BrokerDealers
        {
            get
            {
                return _bdMethods ?? (_bdMethods = new BrokerDealersMethods(AuthToken));
            }
        }

        private ClientsMethods _clientMethods;
        public ClientsMethods Clients
        {
            get
            {
                return _clientMethods ?? (_clientMethods = new ClientsMethods(AuthToken));
            }
        }

        private RegistrationsMethods _registrationMethods;
        public RegistrationsMethods Registrations
        {
            get
            {
                return _registrationMethods ?? (_registrationMethods = new RegistrationsMethods(AuthToken));
            }
        }

        private RepresentativesMethods _repMethods;
        public RepresentativesMethods Representatives
        {
            get
            {
                return _repMethods ?? (_repMethods = new RepresentativesMethods(AuthToken));
            }
        }

        private RiasMethods _riaMethods;
        public RiasMethods Rias
        {
            get
            {
                return _riaMethods ?? (_riaMethods = new RiasMethods(AuthToken));
            }
        }
    }
}
