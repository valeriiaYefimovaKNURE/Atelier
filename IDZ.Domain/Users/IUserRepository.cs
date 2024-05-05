using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ.Domain.Users
{
    public interface IUserRepository
    {
        User? GetByName(string name);
        void Add(User user);
    }
}
