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
    public class SubjectRegisterService : BaseService, ISubjectRegisterService
    {
        public SubjectRegisterService(IUnitOfWork unitOfWork)
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

        public StudentView GetCurrentStudent(IPrincipal user)
        {
            int accountId = 0;

            if (user != null && user.Identity != null)
                int.TryParse(user.Identity.Name, out accountId);

            Account account = UnitOfWork.Select<Account>().FirstOrDefault(acc => acc.Id == accountId);
            if (account != null)
                return UnitOfWork.Select<Student>().To<StudentView>().FirstOrDefault(stu => stu.Code == account.Username);

            return null;
        }

        public IQueryable<ScoreRecordView> GetScoreRecordViews(Int32 studentId, Int32 semesterId)
        {
            return UnitOfWork.Select<ScoreRecord>().To<ScoreRecordView>().Where(sc => sc.StudentId == studentId && sc.SubjectClass.SemesterId == semesterId).OrderBy(sc => sc.Id);
        }

        public IQueryable<SubjectClassView> GetSubjectClassViews(IPrincipal user)
        {
            Semester semester = this.GetCurrentSemester();
            if (semester == null)
                return null;

            StudentView studentView = this.GetCurrentStudent(user);
            if (studentView == null)
                return null;

            StudentClass studentClass = UnitOfWork.Select<StudentClass>().FirstOrDefault(s => s.Id == studentView.StudentClassId);
            if (studentClass == null)
                return null;

            Curriculum curriculum = UnitOfWork.Select<Curriculum>().FirstOrDefault(c => c.Id == studentClass.CurriculumId);
            if (curriculum == null)
                return null;

            IQueryable<CurriculumDetail> curriculumDetails = UnitOfWork.Select<CurriculumDetail>().Where(c => c.CurriculumId == curriculum.Id);
            int[] curriculumDetailIds = curriculumDetails.Select(c => c.SubjectId).ToArray();

            IQueryable<ScoreRecordView> scoreRecords = this.GetScoreRecordViews(studentView.Id, semester.Id);
            int[] scoreRecordIds = scoreRecords.Select(r => r.SubjectClass.SubjectId).ToArray();

            return UnitOfWork
                .Select<SubjectClass>()
                .To<SubjectClassView>()
                .Where(sub => curriculumDetailIds.Any(c => c == sub.SubjectId) && !scoreRecordIds.Any(s => s == sub.SubjectId))
                .OrderByDescending(o => o.Id);
        }


        public void AddSubject(SubjectRegisterCreateView view)
        {
            ScoreRecord scoreRecord = new ScoreRecord();

            scoreRecord.RegigterDate = DateTime.Now;
            scoreRecord.SubjectClassId = view.SubjectClassId;
            scoreRecord.StudentId = view.StudentId;

            UnitOfWork.Insert(scoreRecord);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.DeleteRange(UnitOfWork.Select<ScoreRecordDetail>().Where(s => s.ScoreRecordId == id));
            UnitOfWork.Commit();

            UnitOfWork.Delete<ScoreRecord>(id);
            UnitOfWork.Commit();
        }
    }
}
