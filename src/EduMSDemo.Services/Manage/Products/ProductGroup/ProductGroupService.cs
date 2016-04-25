﻿using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class ProductGroupService : BaseService, IProductGroupService
    {
        public ProductGroupService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductGroup, TView>(id);
        }

        public IQueryable<ProductGroupView> GetViews()
        {
            return UnitOfWork
                .Select<ProductGroup>()
                .To<ProductGroupView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(ProductGroupView view)
        {
            ProductGroup o = UnitOfWork.To<ProductGroup>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(ProductGroupView view)
        {
            ProductGroup o = UnitOfWork.Get<ProductGroup>(view.Id);
            o.Name = view.Name;
            o.Description = view.Description;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductGroup>(id);
            UnitOfWork.Commit();
        }

    }
}
