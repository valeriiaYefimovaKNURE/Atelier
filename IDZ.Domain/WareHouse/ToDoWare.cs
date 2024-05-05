using IDZ.Domain.Abstract;
using IDZ.Domain.Fabric;

namespace IDZ.Domain.WareHouse
{
    public sealed class ToDoWare:Pov
    {
        public List<ToDoFabric> Fabric { get; set; }
        public int ID_Fabric {  get; set; }
        public decimal? Remains {  get; set; }
    }
}
