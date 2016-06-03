using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class TeachingService : BaseService, ITeachingService
    {
        public TeachingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Faculty, TView>(id);
        }

        //public IQueryable<FacultyView> GetViews()
        //{
        //    return UnitOfWork
        //        .Select<Faculty>()
        //        .To<FacultyView>()
        //        .OrderByDescending(o => o.Id);
        //}

        //public void Create(FacultyView view)
        //{
        //    Faculty o = UnitOfWork.To<Faculty>(view);
        //    UnitOfWork.Insert(o);
        //    UnitOfWork.Commit();
        //}

        //public void Edit(FacultyView view)
        //{
        //    Faculty o = UnitOfWork.Get<Faculty>(view.Id);
        //    o.Name = view.Name;
        //    o.Abbreviation = view.Abbreviation;
        //    o.Address = view.Address;
        //    o.Email = view.Email;
        //    o.PhoneNumber = view.PhoneNumber;
        //    o.FaxNumber = view.FaxNumber;

        //    UnitOfWork.Update(o);
        //    UnitOfWork.Commit();
        //}

        //public void Delete(Int32 id)
        //{
        //    UnitOfWork.Delete<Faculty>(id);
        //    UnitOfWork.Commit();
        //}

        public Semester GetCurrentSemester()
        {
            return UnitOfWork.Select<Semester>().FirstOrDefault(se => se.IsCurrentSemester);
        }

        public StaffView GetCurrentTeacher(IPrincipal user)
        {
            int accountId = 0;

            if (user != null && user.Identity != null)
                int.TryParse(user.Identity.Name, out accountId);

            Account account = UnitOfWork.Select<Account>().FirstOrDefault(acc => acc.Id == accountId);
            if (account != null)
                return UnitOfWork.Select<Staff>().To<StaffView>().FirstOrDefault(stu => stu.Code == account.Username);

            return null;
        }


        public IQueryable<SubjectClassView> GetSubjectClassViews(Int32 staffId, Int32 semesterId)
        {
            return UnitOfWork
                .Select<SubjectClass>()
                .To<SubjectClassView>()
                .Where(c => c.StaffId == staffId && c.SemesterId == semesterId)
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<ScoreRecordView> GetScoreRecordViews(Int32 subjectClassId)
        {
            return UnitOfWork
                .Select<ScoreRecord>()
                .To<ScoreRecordView>()
                .Where(s => s.SubjectClassId == subjectClassId)
                .OrderByDescending(o => o.Id);
        }

        public SubjectClassView GetSubjectClassView(Int32 subjectClassId)
        {
            return UnitOfWork.Select<SubjectClass>().To<SubjectClassView>().FirstOrDefault(s => s.Id == subjectClassId);
        }
    }
}
