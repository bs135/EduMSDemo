using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IClassRoomService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ClassRoomView> GetViews();
        IQueryable<BuildingView> GetBuildingViews();

        void Create(ClassRoomView view);
        void Edit(ClassRoomView view);
        void Delete(Int32 id);

    }
}
