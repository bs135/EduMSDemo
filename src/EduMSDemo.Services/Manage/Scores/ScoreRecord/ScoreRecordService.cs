using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class ScoreRecordService : BaseService, IScoreRecordService
    {
        public ScoreRecordService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ScoreRecord, TView>(id);
        }

        public IQueryable<ScoreRecordView> GetViews()
        {
            return UnitOfWork
                .Select<ScoreRecord>()
                .To<ScoreRecordView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<StudentView> GetStudentViews()
        {
            return UnitOfWork
                .Select<Student>()
                .To<StudentView>()
                .OrderByDescending(model => model.Id);
        }

        public IQueryable<SubjectView> GetSubjectViews()
        {
            return UnitOfWork
                .Select<Subject>()
                .To<SubjectView>()
                .OrderByDescending(model => model.Id);
        }

        public IQueryable<SubjectClassView> GetSubjectClassViews()
        {
            return UnitOfWork
                .Select<SubjectClass>()
                .To<SubjectClassView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(ScoreRecordView view)
        {
            ScoreRecord o = UnitOfWork.To<ScoreRecord>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(ScoreRecordView view)
        {
            ScoreRecord o = UnitOfWork.Get<ScoreRecord>(view.Id);
            o.RegigterDate = view.RegigterDate;
            o.StudentId = view.StudentId;
            //o.SubjectId = view.SubjectId;
            o.SubjectClassId = view.SubjectClassId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ScoreRecord>(id);
            UnitOfWork.Commit();
        }

    }
}
