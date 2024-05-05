using IDZ.Domain.Abstract;

namespace IDZ.Domain.Fabric
{
    public interface FabricRepository : IRepository<ToDoFabric>
    {
        void UpdateWarehouse(int id);
        List<string> GetAllName();
        ToDoFabric? GetByName(string name);
    }
}
