using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IBuildingService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<BuildingView> GetViews();

        void Create(BuildingView view);
        void Edit(BuildingView view);
        void Delete(Int32 id);

    }
}
