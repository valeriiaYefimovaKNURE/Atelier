using IDZ.Domain.Abstract;
using IDZ.Domain.Fabric;
using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Sewer;

namespace IDZ.View.ViewModels.Fabrics
{
    internal class FabricsViewModel : GridViewModel<ToDoFabric, FViewModel>
    {
        public FabricsViewModel() : base(new FRepository())
        {
        }
        public override void UpdateFromViewModel(IRepository<ToDoFabric> _r, FViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.NameFabric = viewModel.NameFabric;
                existingModel.Type = viewModel.Type;
                existingModel.CostForMeter = viewModel.Cost;

                _r.Update(existingModel);
            }
        }
        protected override bool Equals(FViewModel originalViewModel, FViewModel viewModel)
            => originalViewModel.Equals(viewModel.NameFabric, viewModel.Type);

        protected override IEnumerable<object?> ExtractColumnValues(FViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.NameFabric;
            yield return viewModel.Type;
            yield return viewModel.Cost;
        }

        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => FViewModel.GetColumns(isAdmin);

        protected override FViewModel Parse(ToDoFabric fabric) => FViewModel.Parse(fabric);

        protected override bool TryParse(DataGridViewRow row, out FViewModel viewModel)
            => FViewModel.TryParse(row, out viewModel);
    }
}
