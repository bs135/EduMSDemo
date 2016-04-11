using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class SystemSettingService : BaseService, ISystemSettingService
    {
        public SystemSettingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SystemSetting, TView>(id);
        }

        public IQueryable<SystemSettingView> GetViews()
        {
            return UnitOfWork
                .Select<SystemSetting>()
                .To<SystemSettingView>()
                .OrderByDescending(systemSetting => systemSetting.Id);
        }

        public void Create(SystemSettingView view)
        {
            SystemSetting SystemSetting = UnitOfWork.To<SystemSetting>(view);
            UnitOfWork.Insert(SystemSetting);
            UnitOfWork.Commit();
        }

        public void Edit(SystemSettingView view)
        {
            SystemSetting SystemSetting = UnitOfWork.Get<SystemSetting>(view.Id);
            SystemSetting.Key = view.Key;
            SystemSetting.ValueDouble = view.ValueDouble;
            SystemSetting.ValueString = view.ValueString;

            UnitOfWork.Update(SystemSetting);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SystemSetting>(id);
            UnitOfWork.Commit();
        }

    }
}
