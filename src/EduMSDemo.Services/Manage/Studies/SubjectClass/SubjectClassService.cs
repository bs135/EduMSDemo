using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class SubjectClassService : BaseService, ISubjectClassService
    {
        public SubjectClassService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SubjectClass, TView>(id);
        }

        public IQueryable<SubjectClassView> GetViews()
        {
            return UnitOfWork
                .Select<SubjectClass>()
                .To<SubjectClassView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<ClassRoomView> GetClassRoomViews()
        {
            return UnitOfWork
                .Select<ClassRoom>()
                .To<ClassRoomView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<SemesterView> GetSemesterViews()
        {
            return UnitOfWork
                .Select<Semester>()
                .To<SemesterView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<SubjectView> GetSubjectViews()
        {
            return UnitOfWork
                .Select<Subject>()
                .To<SubjectView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(SubjectClassView view)
        {
            SubjectClass o = UnitOfWork.To<SubjectClass>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(SubjectClassView view)
        {
            SubjectClass o = UnitOfWork.Get<SubjectClass>(view.Id);
            o.RoomOfClassId = view.RoomOfClassId;
            o.RoomOfMidtermExamId = view.RoomOfMidtermExamId;
            o.RoomOfTermExamId = view.RoomOfTermExamId;
            o.SemesterId = view.SemesterId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SubjectClass>(id);
            UnitOfWork.Commit();
        }

    }
}
