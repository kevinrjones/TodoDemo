using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using ToDo.Infrastructure;
using TodoRepository.Interfaces;
using TodoRepository.Repositories;

namespace Todo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Todo", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            IUnityContainer container = InitializeContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private IUnityContainer InitializeContainer()
        {
            var ctor = new InjectionConstructor(ConfigurationManager.ConnectionStrings["todo"].ConnectionString);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<ITodoRepository, TodosRepository>(ctor);

            return container;
        }
    }
}