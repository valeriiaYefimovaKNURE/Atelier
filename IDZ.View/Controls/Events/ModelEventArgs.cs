using IDZ.Domain.Model;

namespace IDZ.View.Controls.Events
{
    public sealed class ModelEventArgs:EventArgs
    {
        public ToDoModel CurrentModel { get; }

        public ModelEventArgs(ToDoModel currentModel)
        {
            CurrentModel = currentModel;
        }
    }
}
