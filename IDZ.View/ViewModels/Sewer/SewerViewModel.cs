using IDZ.Domain.Abstract;
using IDZ.Domain.Tasks;
using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Warehous;

namespace IDZ.View.ViewModels.Sewer
{
    public sealed class SewerViewModel : GridViewModel<ToDoSewer, SViewModel>
    {
        public SewerViewModel() : base(new SRepository())
        {
        }
        public override void UpdateFromViewModel(IRepository<ToDoSewer> _r, SViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.NameSewer = viewModel.NameSewer;
                existingModel.Payment = viewModel.Payment;
                existingModel.Qualification = viewModel.Qualification;
                existingModel.Workload = viewModel.Workload;

                _r.Update(existingModel);
            }
        }
        protected override bool Equals(SViewModel originalViewModel, SViewModel viewModel)
            => originalViewModel.Equals(viewModel.NameSewer, viewModel.Qualification);

        protected override IEnumerable<object?> ExtractColumnValues(SViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.NameSewer;
            yield return viewModel.Payment;
            yield return viewModel.Qualification;
            yield return viewModel.Workload;
        }

        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => SViewModel.GetColumns(isAdmin);

        protected override SViewModel Parse(ToDoSewer sewer) => SViewModel.Parse(sewer);

        protected override bool TryParse(DataGridViewRow row, out SViewModel viewModel)
           => SViewModel.TryParse(row, out viewModel);
    }
}
