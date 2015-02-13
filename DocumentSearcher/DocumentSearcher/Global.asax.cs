using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DocumentSearcher.App_Start;
using DocumentSearcher.Models.DatabaseAccess.MongoRepositoryImpl;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;

namespace DocumentSearcher
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest()
        {
            if (Request.IsAuthenticated)
            {
                string login = Context.User.Identity.Name;
                var userRepository = NinjectWebCommon.GetKernel().GetService(typeof(IUserRepository)) as IUserRepository;
                Context.User = userRepository.FindByLogin(login);
            }
        }
    }
}
