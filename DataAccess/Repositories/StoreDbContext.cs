using System;
using System.Data.Entity;
using System.Data.OleDb;
using System.Configuration;
using MySql.Data.Entity;
using DataModel.Entities;

namespace DataAccess.Repositories
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]

    public class StoreDbContext : DbContext
    {

        //private static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=StoreDB;Trusted_Connection=True;";
        //private static string backupstring = @"Provider=SQLNCLI11; Server=localhost\SQLEXPRESS; Database=StoreDB; Trusted_Connection=yes";

        private static string SqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public StoreDbContext() : base(SqlConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreDbContext, Migrations.Configuration>(true));
            
            this.Orders = this.Set<Order>();
            this.Users = this.Set<User>();
            this.ProductTypes = this.Set<ProductType>();
            this.Products = this.Set<Product>();
            this.Providers = this.Set<Provider>();
            this.SerialNumbers = this.Set<SerialNumber>();
        }
        public void CreateBackup(string path)
        {
            OleDbConnection connection = new OleDbConnection();
            string name = "StoreDB" + "-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            connection.ConnectionString = "Provider=SQLNCLI11;"+SqlConnectionString;
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = @"
            BACKUP DATABASE [StoreDB] TO  DISK = ? WITH NOFORMAT, NOINIT,  NAME = ?, SKIP, STATS = 10
            ";
            command.Parameters.AddWithValue("@DISK", path+@"\"+name+".bak");
            command.Parameters.AddWithValue("@NAME", name);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            command.Dispose();
        }
        public void CheckIntegrity(string path)
        {
            OleDbConnection connection = new OleDbConnection();
            string name = "StoreDB" + "-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            connection.ConnectionString = "Provider=SQLNCLI11;" + SqlConnectionString; 
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = @"
            RESTORE VERIFYONLY FROM DISK = ?
            ";
            command.Parameters.AddWithValue("@DISK", path + @"\" + name + ".bak");
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            command.Dispose();
        }
    }
}
