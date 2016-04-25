using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class ClassRoomService : BaseService, IClassRoomService
    {
        public ClassRoomService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ClassRoom, TView>(id);
        }

        public IQueryable<ClassRoomView> GetViews()
        {
            return UnitOfWork
                .Select<ClassRoom>()
                .To<ClassRoomView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<BuildingView> GetBuildingViews()
        {
            return UnitOfWork
                .Select<Building>()
                .To<BuildingView>()
                .OrderByDescending(model => model.Id);
        }


        public void Create(ClassRoomView view)
        {
            ClassRoom o = UnitOfWork.To<ClassRoom>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(ClassRoomView view)
        {
            ClassRoom o = UnitOfWork.Get<ClassRoom>(view.Id);
            o.Name = view.Name;
            o.Code = view.Code;
            o.Capacity = view.Capacity;
            o.BuildingId = view.BuildingId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ClassRoom>(id);
            UnitOfWork.Commit();
        }

    }
}
