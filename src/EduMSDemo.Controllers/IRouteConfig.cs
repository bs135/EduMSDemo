using System.Web.Routing;

namespace EduMSDemo.Controllers
{
    public interface IRouteConfig
    {
        void RegisterRoutes(RouteCollection routes);
    }
}
