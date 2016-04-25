﻿using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class SemesterService : BaseService, ISemesterService
    {
        public SemesterService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Semester, TView>(id);
        }

        public IQueryable<SemesterView> GetViews()
        {
            return UnitOfWork
                .Select<Semester>()
                .To<SemesterView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(SemesterView view)
        {
            Semester o = UnitOfWork.To<Semester>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(SemesterView view)
        {
            Semester o = UnitOfWork.Get<Semester>(view.Id);
            o.SchoolYear = view.SchoolYear;
            o.Name = view.Name;
            o.StartDate = view.StartDate;
            o.EndDate = view.EndDate;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Semester>(id);
            UnitOfWork.Commit();
        }

    }
}