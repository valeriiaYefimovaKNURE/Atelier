using IDZ.Domain.Abstract;
using IDZ.Domain.Fabric;
using IDZ.Domain.Model;

namespace IDZ.Domain.Recommend
{
    public sealed class ToDoRecommend:Pov
    {
        public ToDoModel Model { get; set; }
        public ToDoFabric Fabric { get; set; }

        public int Id_Model { get; set; }
        public int Id_Fabric { get; set; }
        public decimal? ExpenseForModel {  get; set; }
    }
}
