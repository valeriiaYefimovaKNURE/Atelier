using Dapper;
using IDZ.Domain.Client;
using IDZ.Domain.Lists;
using IDZ.Persistense.Abstractions;

namespace IDZ.Persistense.Repositories
{
    public sealed class ListRepository :Repository, ClientRepository
    {
        public void Add(ToDoClient list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Client(NameClient,AddressClient,NumClient,Size)" +
                "values(@NameClient,@AddressClient,@NumClient,@Size)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Client where ID_Client=@Id", new {Id=id});
        }

        public ToDoClient? Find(string name, string number)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoClient>("select * from Client where NameClient=@Name AND NumClient=@Number",
                new { Name=name, Number=number });
        }

        public ToDoClient? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoClient>("select * from Client where ID_Client=@Id", new { Id = id });
        }

        public IReadOnlyCollection<ToDoClient> GetAll()
        {
            using var connection = CreateOpenedConnection();
            return connection.Query<ToDoClient>("select * from Client").ToList();
        }

        public void Update(ToDoClient list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Client set NameClient=@NameClient, AddressClient=@AddressClient," +
                " NumClient=@NumClient, Size=@Size where ID_Client=@Id_Client", list);
        }
    }
}
