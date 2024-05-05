using IDZ.Domain.Abstract;

namespace IDZ.Domain.Arrival
{
    public interface ArrivalRepository : IRepository<ToDoArrival>
    {
        IReadOnlyCollection<ToDoArrival> GetByList(int listId);
    }
}
