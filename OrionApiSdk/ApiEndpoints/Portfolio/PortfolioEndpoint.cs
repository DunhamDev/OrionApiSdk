using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class PortfolioEndpoint : ApiEndpointBase, IPortfolioEndpoint
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
        private IAccountsMethods _accountMethods;
        /// <summary>
        /// /Portfolio/Accounts endpoint methods
        /// </summary>
        public IAccountsMethods Accounts
        {
            get
            {
                return _accountMethods ?? (_accountMethods = new AccountsMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="BrokerDealers"/>
        /// </summary>
        private IBrokerDealersMethods _bdMethods;
        /// <summary>
        /// /Portfolio/BrokerDealers endpoint methods
        /// </summary>
        public IBrokerDealersMethods BrokerDealers
        {
            get
            {
                return _bdMethods ?? (_bdMethods = new BrokerDealersMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Clients"/>
        /// </summary>
        private IClientsMethods _clientMethods;
        /// <summary>
        /// /Portfolio/Clients endpoint methods
        /// </summary>
        public IClientsMethods Clients
        {
            get
            {
                return _clientMethods ?? (_clientMethods = new ClientsMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Registrations"/>
        /// </summary>
        private IRegistrationsMethods _registrationMethods;
        /// <summary>
        /// /Portfolio/Registrations endpoint methods
        /// </summary>
        public IRegistrationsMethods Registrations
        {
            get
            {
                return _registrationMethods ?? (_registrationMethods = new RegistrationsMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Representatives"/>
        /// </summary>
        private IRepresentativesMethods _repMethods;
        /// <summary>
        /// /Portfolio/Representatives endpoint methods
        /// </summary>
        public IRepresentativesMethods Representatives
        {
            get
            {
                return _repMethods ?? (_repMethods = new RepresentativesMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Rias"/>
        /// </summary>
        private IRiasMethods _riaMethods;
        /// <summary>
        /// /Portfolio/Rias endpoint methods
        /// </summary>
        public IRiasMethods Rias
        {
            get
            {
                return _riaMethods ?? (_riaMethods = new RiasMethods(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Transactions"/>
        /// </summary>
        private ITransactionsMethods _transactionsMethods;
        /// <summary>
        /// /Portfolio/Transactions endpoint methods
        /// </summary>
        public ITransactionsMethods Transactions
        {
            get
            {
                return _transactionsMethods ?? (_transactionsMethods = new TransactionsMethods(AuthToken));
            }
        }
    }
}
