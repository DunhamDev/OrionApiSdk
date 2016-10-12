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
        /// <summary>
        /// Constructs a /Portfolio endpoint instance
        /// </summary>
        /// <param name="token">The access token of the user making requests</param>
        public PortfolioEndpoint(AuthToken token) : base("Portfolio", token)
        {
        }

        /// <summary>
        /// Endpoint object behind <see cref="Accounts"/>
        /// </summary>
        private AccountsMethods _accountMethods;
        /// <summary>
        /// /Portfolio/Accounts endpoint methods
        /// </summary>
        public AccountsMethods Accounts
        {
            get
            {
                return _accountMethods ?? (_accountMethods = new AccountsMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="BrokerDealers"/> 
        /// </summary>
        private BrokerDealersMethods _bdMethods;
        /// <summary>
        /// /Portfolio/BrokerDealers endpoint methods
        /// </summary>
        public BrokerDealersMethods BrokerDealers
        {
            get
            {
                return _bdMethods ?? (_bdMethods = new BrokerDealersMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Clients"/> 
        /// </summary>
        private ClientsMethods _clientMethods;
        /// <summary>
        /// /Portfolio/Clients endpoint methods
        /// </summary>
        public ClientsMethods Clients
        {
            get
            {
                return _clientMethods ?? (_clientMethods = new ClientsMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Registrations"/> 
        /// </summary>
        private RegistrationsMethods _registrationMethods;
        /// <summary>
        /// /Portfolio/Registrations endpoint methods
        /// </summary>
        public RegistrationsMethods Registrations
        {
            get
            {
                return _registrationMethods ?? (_registrationMethods = new RegistrationsMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Representatives"/> 
        /// </summary>
        private RepresentativesMethods _repMethods;
        /// <summary>
        /// /Portfolio/Representatives endpoint methods
        /// </summary>
        public RepresentativesMethods Representatives
        {
            get
            {
                return _repMethods ?? (_repMethods = new RepresentativesMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Rias"/> 
        /// </summary>
        private RiasMethods _riaMethods;
        /// <summary>
        /// /Portfolio/Rias endpoint methods
        /// </summary>
        public RiasMethods Rias
        {
            get
            {
                return _riaMethods ?? (_riaMethods = new RiasMethods(AuthToken));
            }
        }
    }
}
