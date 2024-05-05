using IDZ.Domain.Abstract;
using IDZ.Domain.Fabric;
using IDZ.Domain.Lists;
using IDZ.Domain.Model;
using IDZ.Domain.Tasks;

namespace IDZ.Domain.Order
{
    public class ToDoOrder:Pov
    {
        public int Id_Order { get; set; }
        public int Id_Client { get; set; } 
        public int Id_Model { get; set; } 
        public int Id_Fabric { get; set; } 
        public int Id_Sewer { get; set; }
        public DateTime? DataTake {  get; set; }
        public DateTime DataDoPlan {  get; set; }
        public DateTime? DataDoReal { get; set; }
        public decimal? CostFabric { get; set; }
        public decimal? CostOrder {  get; set; }
        public decimal? ExpenseFabricReal {  get; set; }
        public bool? Ready { get; set; }

        public ToDoClient? Client { get; set; }
        public ToDoModel? Model { get; set;}
        public ToDoFabric? Fabric { get; set; }
        public ToDoSewer? Sewer { get;set; }

    }
}
