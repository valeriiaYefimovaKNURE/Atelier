using Dapper;
using IDZ.Domain.Sewer;
using IDZ.Domain.Tasks;
using IDZ.Persistense.Abstractions;

namespace IDZ.Persistense.Repositories
{
    public sealed class SRepository : Repository, SewerRepository
    {
        public void Add(ToDoSewer list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Sewer(NameSewer,Payment,Qualification,Workload)" +
                "values(@NameSewer,@Payment,@Qualification,@Workload)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Sewer where ID_Sewer=@Id", new { Id = id });
        }

        public ToDoSewer? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoSewer>("select * from Sewer where ID_Sewer=@Id", new { Id = id });
        }

        public IReadOnlyCollection<ToDoSewer> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoSewer>("select * from Sewer").ToList();
        }

        public void Update(ToDoSewer list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Sewer set NameSewer=@NameSewer, Payment=@Payment," +
                " Qualification=@Qualification, Workload=@Workload where ID_Sewer=@Id", list);
        }

        public void UpdateWork(ToDoSewer list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Sewer set Workload=@Workload where ID_Sewer=@Id_Sewer", list);
        }
    }
}
