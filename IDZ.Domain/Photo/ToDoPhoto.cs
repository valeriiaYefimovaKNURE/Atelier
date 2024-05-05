using IDZ.Domain.Abstract;
using IDZ.Domain.Model;
using System.Drawing;

namespace IDZ.Domain.Photo
{
    public sealed class ToDoPhoto:Pov
    {
        public int Id_Photo { get; set; }
        public Image? Picture { get; set; }
        public string link {  get; set; }=string.Empty;

        public ToDoModel? Model { get; set; }
        public int? Id_Model { get; set; }
    }
}
