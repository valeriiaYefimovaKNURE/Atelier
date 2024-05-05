using IDZ.Domain.Abstract;
using System.Drawing;

namespace IDZ.Domain.Photo
{
    public interface PhotoRepository: IRepository<ToDoPhoto>
    {
        void Insert(int model, string fileName, byte[] image);
        Image? GetPhoto(int model);
    }
}
