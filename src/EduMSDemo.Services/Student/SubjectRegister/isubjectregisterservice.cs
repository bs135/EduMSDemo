using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ISubjectRegisterService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        //IQueryable<FacultyView> GetViews();

        //void Create(FacultyView view);
        //void Edit(FacultyView view);
        //void Delete(Int32 id);

        Semester GetCurrentSemester();
        StudentView GetCurrentStudent(IPrincipal user);
        IQueryable<SubjectClassView> GetSubjectClassViews(IPrincipal user);
        void AddSubject(SubjectRegisterCreateView view);
        IQueryable<ScoreRecordView> GetScoreRecordViews(Int32 studentId, Int32 semesterId);
        void Delete(Int32 id);
    }
}
