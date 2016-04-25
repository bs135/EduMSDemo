using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IFacultyService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<FacultyView> GetViews();

        void Create(FacultyView view);
        void Edit(FacultyView view);
        void Delete(Int32 id);

    }
}
