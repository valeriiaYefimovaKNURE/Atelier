using Dapper;
using IDZ.Domain.Users;
using IDZ.Persistense.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ.Persistense.Repositories
{
    public sealed class UserRepository : Repository, IUserRepository
    {
        public void Add(User user)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("Insert into Users (Name,Password,Role) Values(@Name,@Password,'SIMPLE')", user);
        }

        public User? GetByName(string name)
        {
            using var connection = CreateOpenedConnection();
            return connection.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Name=@Name", new { Name = name });
        }
    }
}
