using IDZ.Domain.Abstract;

namespace IDZ.Domain.Tasks
{
    public sealed class ToDoSewer:Pov
    {
        public int Id_Sewer { get; set; }
        public string NameSewer { get; set; } = string.Empty;
        public double Payment { get; set; }
        public string? Qualification { get; set; }
        public int Workload { get; set; }
    }
}
