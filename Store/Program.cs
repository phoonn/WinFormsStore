using DataAccess.Repositories;
using DataModel.Entities;
using Store.ProductForms;
using System;
using System.Windows.Forms;
using Unity;

namespace Store
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                if (context.Database.CreateIfNotExists())
                {
                    User user = new User();
                    user.Id = 1;
                    user.Username = "admin";
                    user.Password = "admin";
                    user.IsMaster = true;
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            UnityContainer container = new UnityContainer();
            Bindings.RegisterTypes(container);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(container.Resolve<ProductView>());
            Application.Run(container.Resolve<Login>());

            
        }
    }
}
