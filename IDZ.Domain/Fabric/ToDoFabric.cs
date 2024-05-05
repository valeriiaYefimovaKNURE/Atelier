using IDZ.Domain.Recommend;
using IDZ.Domain.Abstract;

namespace IDZ.Domain.Fabric
{
    public sealed class ToDoFabric:Pov
    {
        public int Id_Fabric { get; set; }
        public string NameFabric{ get; set; } = string.Empty;
        public string? Type { get; set; }
        public decimal? CostForMeter { get; set; }

        public List<ToDoRecommend>? Recommends { get; set; }
    }
}
