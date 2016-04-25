using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class BonusScoreService : BaseService, IBonusScoreService
    {
        public BonusScoreService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<BonusScore, TView>(id);
        }

        public IQueryable<BonusScoreView> GetViews()
        {
            return UnitOfWork
                .Select<BonusScore>()
                .To<BonusScoreView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<StudentView> GetStudentViews()
        {
            return UnitOfWork
                .Select<Student>()
                .To<StudentView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(BonusScoreView view)
        {
            BonusScore o = UnitOfWork.To<BonusScore>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(BonusScoreView view)
        {
            BonusScore o = UnitOfWork.Get<BonusScore>(view.Id);
            o.Score = view.Score;
            o.Note = view.Note;
            o.StudentId = view.StudentId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<BonusScore>(id);
            UnitOfWork.Commit();
        }

    }
}
