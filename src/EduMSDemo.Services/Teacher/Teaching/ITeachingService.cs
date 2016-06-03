using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ITeachingService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        //IQueryable<FacultyView> GetViews();

        //void Create(FacultyView view);
        //void Edit(FacultyView view);
        //void Delete(Int32 id);

        Semester GetCurrentSemester();
        StaffView GetCurrentTeacher(IPrincipal user);
        IQueryable<SubjectClassView> GetSubjectClassViews(Int32 staffId, Int32 semesterId);
        IQueryable<ScoreRecordView> GetScoreRecordViews(Int32 subjectClassId);
        SubjectClassView GetSubjectClassView(Int32 subjectClassId);
        ScoreRecordView GetScoreRecordView(Int32 scoreRecordViewId);
        void UpdateScoreRecord(UpdateScoreView view);
        Int32 GetSubjectClassId(UpdateScoreView view);
    }
}
