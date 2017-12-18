using DataAccess.Repositories;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using BusinessLogic;
using System.Windows.Forms;
using Store.Users;
using Unity.Injection;
using Store.ProductForms;
using Interfaces.Repositories;
using DataModel.Entities;
using Interfaces.Logic;
using Store.Factories.Interfaces;
using Store.Factories;

namespace Store
{
    public class Bindings 
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            
            //Repositories
            container.RegisterType<IOrderRepository<Order>,OrderRepository>();
            container.RegisterType<IUserRepository<User>, UserRepository>();
            container.RegisterType<IProductRepository<Product>, ProductRepository>();
            container.RegisterType<IProductTypeRepository<ProductType>, ProductTypeRepository>();
            container.RegisterType<IProviderRepository<Provider>, ProviderRepository>();
            container.RegisterType<ISerialNumberRepository<SerialNumber>, SerialNumberRepository>();
            container.RegisterType(typeof(IRepository<>), typeof(BaseRepository<>));

            //Context and Unit
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<DbContext, StoreDbContext>(new PerResolveLifetimeManager());

            //Logic
            container.RegisterType<IOrderLogic<Order>, OrderLogic>();
            container.RegisterType<IUserLogic<User>, UserLogic>();
            container.RegisterType<IProductLogic<Product>, ProductLogic>();
            container.RegisterType<IProviderLogic<Provider>, ProviderLogic>();
            container.RegisterType<IProductTypeLogic<ProductType>, ProductTypeLogic>();

            //Forms
            container.RegisterType<Form, Login>();
            container.RegisterType<Form, OrdersManager>(new InjectionConstructor(new User(),new ResolvedParameter<IOrderLogicFactory>(), new ResolvedParameter<IUserLogicFactory>()));
            container.RegisterType<Form, ManageUsers>();
            container.RegisterType<Form, ProductView>();

            //Factories
            container.RegisterType<IOrdersManagerFactory, OrdersManagerFactory>();
            container.RegisterType<IOrderLogicFactory, OrderLogicFactory>();
            container.RegisterType<IUserLogicFactory, UserLogicFactory>();
            container.RegisterType<IFormFactory, ProductViewFactory>("productview");
            container.RegisterType<IFormFactory, ManageUsersFactory>("manageusers");

            //container 
            container.RegisterInstance<IUnityContainer>(container);
        }
    }
}
