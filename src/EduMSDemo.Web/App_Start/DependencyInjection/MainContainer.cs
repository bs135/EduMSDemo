using LightInject;
using EduMSDemo.Components.Logging;
using EduMSDemo.Components.Mail;
using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Controllers;
using EduMSDemo.Data.Core;
using EduMSDemo.Data.Logging;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System.Data.Entity;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EduMSDemo.Web.DependencyInjection
{
    public class MainContainer : ServiceContainer
    {
        public void RegisterServices()
        {
            Register<DbContext, Context>();
            Register<IUnitOfWork, UnitOfWork>();

            Register<ILogger, Logger>();
            Register<IAuditLogger, AuditLogger>();

            Register<IHasher, BCrypter>();
            Register<IMailClient, SmtpMailClient>();

            Register<IRouteConfig, RouteConfig>();
            Register<IBundleConfig, BundleConfig>();
            //Register<IExceptionFilter, ExceptionFilter>();

            Register<IMvcSiteMapParser, MvcSiteMapParser>();
            Register<IMvcSiteMapProvider>(factory => new MvcSiteMapProvider(
                 HostingEnvironment.MapPath("~/Mvc.sitemap"), factory.GetInstance<IMvcSiteMapParser>()));

            Register<IGlobalizationProvider>(factory =>
                new GlobalizationProvider(HostingEnvironment.MapPath("~/Globalization.xml")));
            RegisterInstance<IAuthorizationProvider>(new AuthorizationProvider(typeof(BaseController).Assembly));

            // service

            #region Admin service
            Register<IRoleService, RoleService>();
            Register<IAccountService, AccountService>();
            Register<ISystemSettingService, SystemSettingService>();
            #endregion

            #region Product service
            Register<IProductService, ProductService>();
            Register<IProductGroupService, ProductGroupService>();
            #endregion


            // Validator

            #region Admin validator
            Register<IRoleValidator, RoleValidator>();
            Register<IAccountValidator, AccountValidator>();
            Register<ISystemSettingValidator, SystemSettingValidator>();
            #endregion

            #region Product validator
            Register<IProductValidator, ProductValidator>();
            Register<IProductGroupValidator, ProductGroupValidator>();
            #endregion

        }
    }
}
