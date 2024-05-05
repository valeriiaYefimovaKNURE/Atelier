
using IDZ.Domain.Abstract;
using IDZ.Domain.Fabric;
using IDZ.Domain.Maker;

namespace IDZ.Domain.Arrival
{
    public class ToDoArrival:Pov
    {
        public int? Id_Arrival { get; set; }
        public ToDoMaker? Maker { get; set; }
        public ToDoFabric? Fabric { get; set; }  
        public double Quantity {  get; set; }
        public DateTime DateArrival { get; set; }
    }
}
