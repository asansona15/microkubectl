using Microservice.ECommerce.UserApp.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.ECommerce.UserApp.EFDataContext
{
    //public class UserDataContext : DbContext
    //{
    //    private readonly IConfiguration configuration;

    //    public UserDataContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    //    {
    //        this.configuration = configuration;
    //    }

    //    public DbSet<User> Users { get; set; }
    //}

    public class UserDataContext
    {
        public string ConnectionString { get; set; }

        public UserDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
