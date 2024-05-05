using Dapper;
using IDZ.Domain.Lists;
using IDZ.Domain.WareHouse;
using IDZ.Persistense.Abstractions;

namespace IDZ.Persistense.Repositories
{
    public sealed class WRepository : Repository, WareRepository
    {
        public void Add(ToDoWare list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Warehouse(ID_Fabric, Remains)" +
                "values(@IdFabric,@Remains)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Warehouse where ID_Fabric=@Id", new { Id = id });
        }

        public ToDoWare? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoWare>("select * from Warehouse where ID_Fabric=@Id", new { Id = id });
        }

        public IReadOnlyCollection<ToDoWare> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoWare>("select * from Warehouse").ToList();
        }

        public void Update(ToDoWare list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Warehouse set Remains=@Remains where ID_Fabric=@IdFabric", list);
        }
    }
}
