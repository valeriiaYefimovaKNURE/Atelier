using IDZ.Domain.Abstract;
using IDZ.Domain.Lists;

namespace IDZ.Domain.Client
{
    public interface ClientRepository : IRepository<ToDoClient>
    {
        public ToDoClient? Find(string name, string number);
    }
}
