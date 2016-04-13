using AutoMapper;
using EduMSDemo.Objects;
using System.Collections.Generic;

namespace EduMSDemo.Data.Mapping
{
    public class ObjectMapper
    {
        public static void MapObjects()
        {
            Mapper.Initialize(configuration => new ObjectMapper(configuration).Map());
        }

        private IMapperConfiguration Configuration { get; set; }

        private ObjectMapper(IMapperConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void Map()
        {
            MapRoles();
            MapAccounts();
            MapProducts();
            //Mapper.Configuration.Seal();
        }

        #region Administration

        private void MapRoles()
        {
            Configuration.CreateMap<Role, RoleView>()
                .ForMember(role => role.Permissions, member => member.Ignore());
            Configuration.CreateMap<RoleView, Role>()
                .ForMember(role => role.Permissions, member => member.UseValue(new List<RolePermission>()));
        }
        private void MapAccounts()
        {
            Configuration.CreateMap<Account, AccountView>();
            Configuration.CreateMap<Account, AccountEditView>();
            Configuration.CreateMap<Account, ProfileEditView>();

            Configuration.CreateMap<AccountCreateView, Account>();
            Configuration.CreateMap<AccountRegisterView, Account>();

            Configuration.CreateMap<Account, AccountDeleteView>();


            Configuration.CreateMap<SystemSetting, SystemSettingView>();
            Configuration.CreateMap<SystemSettingView, SystemSetting>();
        }

        #endregion

        #region Products
        private void MapProducts()
        {
            Configuration.CreateMap<Product, ProductView>();
            Configuration.CreateMap<ProductView, Product>();

            Configuration.CreateMap<ProductGroup, ProductGroupView>();
            Configuration.CreateMap<ProductGroupView, ProductGroup>();
        }
        #endregion

        #region Teacher


        #endregion
    }
}
