using Dapper;
using IDZ.Domain.Fabric;
using IDZ.Persistense.Abstractions;
using System.Collections.Generic;

namespace IDZ.Persistense.Repositories
{
    public sealed class FRepository : Repository, FabricRepository, IDisposable
    {
        public void Add(ToDoFabric list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Fabric(NameFabric,Type,CostForMeter)" +
                "values(@NameFabric,@Type,@CostForMeter)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Fabric where ID_Fabric=@Id", new { Id = id });
        }

        public void Dispose()
        {
        }

        public ToDoFabric? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoFabric>("select * from Fabric where ID_Fabric=@Id", new { Id = id });
        }

        public IReadOnlyCollection<ToDoFabric> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoFabric>("select * from Fabric").ToList();
        }
        public List<string> GetAllName()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<string>("select NameFabric from Fabric").ToList();
        }

        public ToDoFabric? GetByName(string name)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoFabric>("select * from Fabric where NameFabric=@Name", new { Name = name});
        }

        public void Update(ToDoFabric list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Fabric set NameFabric=@NameFabric, Type=@Type," +
                " CostForMeter=@CostForMeter where ID_Fabric=@Id", list);
        }

        public void UpdateWarehouse(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Warehouse set ID_Fabric=@Id", new { Id = id }).ToList();
        }
    }
}
