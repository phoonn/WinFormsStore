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
using System.Collections.Generic;

namespace Store
{
    public class Bindings 
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            
            //Repositories
            container.RegisterType<IOrderRepository,OrderRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductTypeRepository, ProductTypeRepository>();
            container.RegisterType<IProviderRepository, ProviderRepository>();
            container.RegisterType<ISerialNumberRepository, SerialNumberRepository>();
            container.RegisterType(typeof(IRepository<>), typeof(BaseRepository<>));

            //Context and Unit
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<DbContext, StoreDbContext>(new PerResolveLifetimeManager());

            //Logic
            container.RegisterType<IOrderLogic, OrderLogic>();
            container.RegisterType<IUserLogic, UserLogic>();
            container.RegisterType<IProductLogic, ProductLogic>();
            container.RegisterType<IProviderLogic, ProviderLogic>();
            container.RegisterType<IProductTypeLogic, ProductTypeLogic>();
            container.RegisterType<ISerialNumberLogic, SerialNumberLogic>();

            //Forms
            List<SerialNumber> seriallist = new List<SerialNumber>();
            container.RegisterType<Form, Login>();
            container.RegisterType<Form, OrdersManager>(new InjectionConstructor(new User(),new ResolvedParameter<IOrderLogicFactory>(), new ResolvedParameter<IUserLogicFactory>()));
            container.RegisterType<Form, ManageUsers>();
            container.RegisterType<Form, ProductView>();
            container.RegisterType<Form, SerialNumbers>(new InjectionConstructor(seriallist,new ResolvedParameter<ISerialNumberLogic>()));

            //Factories
            container.RegisterType<IOrdersManagerFactory, OrdersManagerFactory>();
            container.RegisterType<IOrderLogicFactory, OrderLogicFactory>();
            container.RegisterType<IUserLogicFactory, UserLogicFactory>();
            container.RegisterType<IProductLogicFactory, ProductLogicFactory>();
            container.RegisterType<ISerialNumberLogicFactory, SerialNumberLogicFactory>();
            container.RegisterType<IProviderLogicFactory, ProviderLogicFactory>();
            container.RegisterType<IProductTypeLogicFactory, ProductTypeLogicFactory>();
            container.RegisterType<IFormFactory, ProductViewFactory>("productview");
            container.RegisterType<IFormFactory, ManageUsersFactory>("manageusers");
            container.RegisterType<ISerialNumbersFormFactory, SerialNumbersFormFactory>();

            //container 
            container.RegisterInstance<IUnityContainer>(container);
        }
    }
}
