using Dapper;
using IDZ.Domain.Lists;
using IDZ.Domain.Recommend;
using IDZ.Persistense.Abstractions;

namespace IDZ.Persistense.Repositories
{
    public sealed class RRepository : Repository, RecRepository
    {
        public void Add(ToDoRecommend list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Recommend(ID_Fabric,ID_Model,ExpenseForModel)" +
                "values(@Id_Fabric,@Id_Model,@ExpenseForModel)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Recommend where ID_Fabric=@Id", new { Id = id });
        }

        public void DeleteModel(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Recommend where ID_Model=@Id", new { Id = id });
        }

        public ToDoRecommend? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoRecommend>("select * from Recommend where ID_Fabric=@Id", new { Id = id });
        }
        public ToDoRecommend? GetByModel(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoRecommend>("select * from Recommend where ID_Model=@Id", new { Id = id });
        }
        public IReadOnlyCollection<ToDoRecommend> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoRecommend>("select * from Recommend").ToList();
        }
        public void Update(ToDoRecommend list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Recommend set ID_Fabric=@Id_Fabric, ID_Model=@Id_Model," +
                " ExpenseForModel=@ExpenseForModel where ID_Fabric=@Id_Fabric", list);
        }

        public ToDoRecommend? Find(int idFabric, int idModel)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoRecommend>("select * from Recommend where ID_Model=@IdModel AND ID_Fabric=@IdFabric", 
                new { IdFabric = idFabric, IdModel=idModel });
        }
    }
}
