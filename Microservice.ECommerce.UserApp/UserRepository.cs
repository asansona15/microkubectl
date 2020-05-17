using Microservice.ECommerce.UserApp.EFDataContext;
using Microservice.ECommerce.UserApp.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.ECommerce.UserApp
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDataContext userDataContext;

        public UserRepository(UserDataContext userDataContext)
        {
            this.userDataContext = userDataContext;
        }

        public IList<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = this.userDataContext.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from User", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                        });
                    }
                }
            }

            return list;
        }
    }

    public interface IUserRepository
    {
        IList<User> GetAllUsers();
    }
}
