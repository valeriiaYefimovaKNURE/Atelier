using IDZ.Domain.Abstract;
namespace IDZ.View.ViewModels
{
    public abstract class ViewModel<TPov> where TPov : Pov
    {
        public const string IdColumnName = "Id";
        public int Id {  get; set; }
        public abstract TPov ToModel();
        
    }
}
