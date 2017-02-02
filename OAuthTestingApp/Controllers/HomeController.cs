using OrionApiSdk;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OAuthTestingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public async Task<JsonResult> Query()
        {
            AuthToken token = new AuthToken()
            {
                AccessToken = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type.EndsWith("access_token")).Value,
            };
            IOrionApi Api = new OrionApi(token);
            Api.UseTestApi();
            var newAccount = new AccountVerbose()
            {
                Name = "Api Testing Account",
                Portfolio = new AccountPortfolio
                {
                    RegistrationId = 1,
                    Salutation = "Mr.",
                    FirstName = "Test",
                    LastName = "Account",
                    Name = "Api Testing Account",
                    SSN_TaxID = "555-66-7777",
                    Address1 = "10251 Vista Sorrento Parkway",
                    City = "San Diego",
                    State = "CA",
                    Zip = "92121",
                    Email = "billy.wolfington@dunham.com",
                    AccountType = "401(k)",
                    CustodianId = 66,
                    ManagementStyle = "Managed Account",
                    FundFamilyId = 1022,
                    AccountStartDate = DateTime.Now,
                    AccountStatusId = 5,
                },
                Billing = new AccountBilling
                {
                    ValuationMethod = "Period End Value",
                    BillStyle = "Advanced",
                    BillFrequency = "Quarterly",
                }
            };
            newAccount = await Api.Portfolio.Accounts.CreateAsync(newAccount);

            return Json(newAccount);
        }
    }
}