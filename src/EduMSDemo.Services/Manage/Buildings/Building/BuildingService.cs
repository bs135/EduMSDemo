using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Building, TView>(id);
        }

        public IQueryable<BuildingView> GetViews()
        {
            return UnitOfWork
                .Select<Building>()
                .To<BuildingView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(BuildingView view)
        {
            Building o = UnitOfWork.To<Building>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(BuildingView view)
        {
            Building o = UnitOfWork.Get<Building>(view.Id);
            o.Name = view.Name;
            o.Code = view.Code;
            o.RoomCount = view.RoomCount;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Building>(id);
            UnitOfWork.Commit();
        }

    }
}
