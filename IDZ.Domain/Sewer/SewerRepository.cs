using IDZ.Domain.Abstract;
using IDZ.Domain.Tasks;

namespace IDZ.Domain.Sewer
{
    public interface SewerRepository:IRepository<ToDoSewer>
    {
        public void UpdateWork(ToDoSewer list);
    }
}
