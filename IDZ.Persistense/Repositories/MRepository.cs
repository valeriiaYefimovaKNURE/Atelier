using Dapper;
using IDZ.Domain.Model;
using IDZ.Persistense.Abstractions;

namespace IDZ.Persistense.Repositories
{
    public sealed class MRepository : Repository, ModelRepository,IDisposable
    {
        public void Add(ToDoModel list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Model(ExpenseFabric,PlanTime,CostModel,AdditionalCost)" +
                "values(@ExpenseFabric,@PlanTime,@CostModel,@AdditionalCost)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Model where ID_Model=@Id", new { Id = id });
        }

        public void Dispose()
        {
            
        }

        public ToDoModel? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoModel>("select * from Model where ID_Model=@Id", new { Id = id });
        }

        public IReadOnlyCollection<ToDoModel> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoModel>("select * from Model").ToList();
        }
        public List<int> GetAllId()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<int>("select Id_Model from Model").ToList();
        }

        public void Update(ToDoModel list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Model set ExpenseFabric=@ExpenseFabric, PlanTime=@PlanTime," +
                " CostModel=@CostModel, AdditionalCost=@AdditionalCost where ID_Model=@Id", list);
        }
    }
}
