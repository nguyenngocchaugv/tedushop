using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TeduShop.Web.App_Start;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private TeduShop.Web.App_Start.ApplicationUserStore.ApplicationSignInManager _signInManager;
        private TeduShop.Web.App_Start.ApplicationUserStore.ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(TeduShop.Web.App_Start.ApplicationUserStore.ApplicationUserManager userManager, TeduShop.Web.App_Start.ApplicationUserStore.ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public TeduShop.Web.App_Start.ApplicationUserStore.ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<TeduShop.Web.App_Start.ApplicationUserStore.ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public TeduShop.Web.App_Start.ApplicationUserStore.ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<TeduShop.Web.App_Start.ApplicationUserStore.ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password, bool rememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
