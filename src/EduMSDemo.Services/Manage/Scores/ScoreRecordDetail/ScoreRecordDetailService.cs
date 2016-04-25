using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class ScoreRecordDetailService : BaseService, IScoreRecordDetailService
    {
        public ScoreRecordDetailService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ScoreRecordDetail, TView>(id);
        }

        public IQueryable<ScoreRecordDetailView> GetViews()
        {
            return UnitOfWork
                .Select<ScoreRecordDetail>()
                .To<ScoreRecordDetailView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<ScoreRecordView> GetScoreRecordViews()
        {
            return UnitOfWork
                .Select<ScoreRecord>()
                .To<ScoreRecordView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(ScoreRecordDetailView view)
        {
            ScoreRecordDetail o = UnitOfWork.To<ScoreRecordDetail>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(ScoreRecordDetailView view)
        {
            ScoreRecordDetail o = UnitOfWork.Get<ScoreRecordDetail>(view.Id);
            o.MidTermScore = view.MidTermScore;
            o.TermScore = view.TermScore;
            o.FinalScore = view.FinalScore;
            o.DateOfScore = view.DateOfScore;
            o.ScoreRecordId = view.ScoreRecordId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ScoreRecordDetail>(id);
            UnitOfWork.Commit();
        }

    }
}
