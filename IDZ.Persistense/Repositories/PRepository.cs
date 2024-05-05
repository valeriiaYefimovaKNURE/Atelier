using Dapper;
using IDZ.Domain.Lists;
using IDZ.Domain.Photo;
using IDZ.Persistense.Abstractions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace IDZ.Persistense.Repositories
{
    public sealed class PRepository : Repository, PhotoRepository
    {
        public void Add(ToDoPhoto list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("insert into Photo(Id_Model,Link,Image)" +
                "values(@ID_Model,@link,@Image)", list);
        }

        public void Delete(int id)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("delete from Photo where ID_Photo=@Id", new { Id = id });
        }

        public ToDoPhoto? Get(int id)
        {
            using var connection = CreateOpenedConnection();
            return connection.QueryFirstOrDefault<ToDoPhoto>("select * from Photo where ID_Photo=@Id", new { Id = id });
        }
        public Image? GetPhoto(int model)
        {
            using var connection = CreateOpenedConnection();
            var photo = connection.QueryFirstOrDefault<ToDoPhoto>("select Link from Photo where Id_Model=@Id", new { Id = model });

            if (photo != null && !string.IsNullOrEmpty(photo.link))
            {
                byte[] imageBytes = GetImageBytes(photo.link);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }

            return null;
        }
        public IReadOnlyCollection<ToDoPhoto> GetAll()
        {
            using var connection = CreateOpenedConnection();

            var photos = connection.Query<ToDoPhoto>("SELECT Id_Photo, Id_Model, Link FROM Photo").ToList();

            foreach (var photo in photos)
            {
                if (!string.IsNullOrEmpty(photo.link))
                {
                    byte[] imageBytes = GetImageBytes(photo.link);

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        photo.Picture = Image.FromStream(ms);
                    }
                }
            }
            return photos;
        }
        private byte[] GetImageBytes(string link)
        {
            try
            {
                if (File.Exists(link))
                {
                    return File.ReadAllBytes(link);
                }
                else
                {
                    return Array.Empty<byte>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return Array.Empty<byte>();
            }
        }
        public void Insert(int model, string fileName, byte[] image)
        {
            using (var connection = CreateOpenedConnection())
            {
                using (SqlCommand cmd = new SqlCommand("insert into Photo(Id_Model,Link,Picture) values(@Id_Model,@File,@img)",connection))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id_Model", model);
                    cmd.Parameters.AddWithValue("@File", fileName);
                    cmd.Parameters.AddWithValue("@img", image);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(ToDoPhoto list)
        {
            using var connection = CreateOpenedConnection();
            connection.Query("update Photo set Link=@link, Image=@Image", list);
        }
    }
}
