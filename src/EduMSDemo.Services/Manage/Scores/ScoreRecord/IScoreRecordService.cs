using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IScoreRecordService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ScoreRecordView> GetViews();
        IQueryable<StudentView> GetStudentViews();
        IQueryable<SubjectView> GetSubjectViews();
        IQueryable<SubjectClassView> GetSubjectClassViews();
        void Create(ScoreRecordView view);
        void Edit(ScoreRecordView view);
        void Delete(Int32 id);

    }
}
