using IDZ.Domain.Abstract;
using IDZ.Domain.Photo;

namespace IDZ.Domain.Model
{
    public sealed class ToDoModel:Pov
    {
        public int Id_Model { get; set; }
        public decimal? ExpenseFabric {  get; set; }
        public int? PlanTime {  get; set; }
        public decimal? CostModel { get; set; }
        public decimal? AdditionalCost {  get; set; }

        public ICollection<ToDoPhoto> Photos { get; set; } = new List<ToDoPhoto>();
        public int? getId()
        {
            return Id_Model;
        }
    }
}
