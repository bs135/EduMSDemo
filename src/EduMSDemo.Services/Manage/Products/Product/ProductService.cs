using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Product, TView>(id);
        }

        public IQueryable<ProductView> GetViews()
        {
            return UnitOfWork
                .Select<Product>()
                .To<ProductView>()
                .OrderByDescending(product => product.Id);
        }

        public IQueryable<ProductGroupView> GetGroupViews()
        {
            return UnitOfWork
                .Select<ProductGroup>()
                .To<ProductGroupView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(ProductView view)
        {
            Product product = UnitOfWork.To<Product>(view);
            UnitOfWork.Insert(product);
            UnitOfWork.Commit();
        }

        public void Edit(ProductView view)
        {
            Product product = UnitOfWork.Get<Product>(view.Id);
            product.Name = view.Name;
            product.SKU = view.SKU;
            product.StockQuanlity = view.StockQuanlity;
            product.ProductGroupId = view.ProductGroupId;
            product.IsActive = view.IsActive;

            UnitOfWork.Update(product);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Product>(id);
            UnitOfWork.Commit();
        }

    }
}
