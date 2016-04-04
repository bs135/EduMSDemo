using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ISystemSettingService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SystemSettingView> GetViews();
        void Create(SystemSettingView view);
        void Edit(SystemSettingView view);
        void Delete(Int32 id);

    }
}
