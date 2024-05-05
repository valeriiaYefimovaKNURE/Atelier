using IDZ.Domain.Abstract;

namespace IDZ.Domain.Model
{
    public interface ModelRepository:IRepository<ToDoModel>
    {
        List<int> GetAllId();
    }
}
