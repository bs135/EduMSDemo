using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IProductGroupService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductGroupView> GetViews();
        void Create(ProductGroupView view);
        void Edit(ProductGroupView view);
        void Delete(Int32 id);

    }
}
