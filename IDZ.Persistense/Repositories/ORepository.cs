using Dapper;
using IDZ.Domain.Order;
using IDZ.Persistense.Abstractions;

namespace IDZ.Persistense.Repositories
{
    public sealed class ORepository : Repository, OrderRepository
    {
        public void Add(ToDoOrder list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Orderr(ID_Client,ID_Model,ID_Fabric,ID_Sewer,DataTake,DataDoPlan,DataDoReal,CostFabric,CostOrder,ExpenseFabricReal,ReadyMark)" +
                "values(@Id_Client,@Id_Model,@Id_Fabric,@Id_Sewer, @DataTake, @DataDoPlan, @DataDoReal, @CostFabric, @CostOrder, @ExpenseFabricReal, @Ready)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Orderr where Id_Order=@Id", new { Id = id });
        }

        public ToDoOrder? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoOrder>("select * from Orderr where Id_Order=@Id", new { Id = id });
        }

        public IReadOnlyCollection<ToDoOrder> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoOrder>("select * from Orderr").ToList();
        }

        public void Update(ToDoOrder list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Orderr set Id_Sewer=@Id_Sewer, DataDoPlan=@DataDoPlan, " +
                " DataDoReal=@DataDoReal, Ready=@Ready where Id_Order=@Id_Order", list);
        }
    }
}
