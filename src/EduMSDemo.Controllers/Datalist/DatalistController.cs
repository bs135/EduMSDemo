using Datalist;
using EduMSDemo.Components.Datalists;
using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Web.Mvc;
using System.Web.SessionState;

namespace EduMSDemo.Controllers
{
    [AllowUnauthorized]
    [SessionState(SessionStateBehavior.ReadOnly)]
    public class DatalistController : BaseController
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private Boolean Disposed { get; set; }

        public DatalistController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [NonAction]
        public virtual JsonResult GetData(AbstractDatalist datalist, DatalistFilter filter)
        {
            datalist.CurrentFilter = filter;

            return Json(datalist.GetData(), JsonRequestBehavior.AllowGet);
        }
        #region Account
        [AjaxOnly]
        public JsonResult Role(DatalistFilter filter)
        {
            return GetData(new Datalist<Role, RoleView>(UnitOfWork), filter);
        }

        public JsonResult Account(DatalistFilter filter)
        {
            return GetData(new Datalist<Account, AccountView>(UnitOfWork), filter);
        }

        #endregion

        protected override void Dispose(Boolean disposing)
        {
            if (Disposed) return;

            UnitOfWork.Dispose();
            Disposed = true;

            base.Dispose(disposing);
        }
    }
}
