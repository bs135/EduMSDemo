using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IProductService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductView> GetViews();

        IQueryable<ProductGroupView> GetGroupViews();
        void Create(ProductView view);
        void Edit(ProductView view);
        void Delete(Int32 id);

    }
}
