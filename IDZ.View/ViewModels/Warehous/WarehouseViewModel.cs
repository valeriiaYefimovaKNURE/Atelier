using IDZ.Domain.Abstract;
using IDZ.Domain.WareHouse;
using IDZ.Persistense.Repositories;

namespace IDZ.View.ViewModels.Warehous
{
    public sealed class WarehouseViewModel : GridViewModel<ToDoWare, WViewModel>
    {

        public WarehouseViewModel() : base(new WRepository())
        {
        }

        public override void UpdateFromViewModel(IRepository<ToDoWare> _r,WViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.Remains = viewModel.Remains;

                _r.Update(existingModel);
            }
        }

        protected override bool Equals(WViewModel originalViewModel, WViewModel viewModel)
            => WViewModel.Equals(viewModel.Id, viewModel.Remains);

        protected override IEnumerable<object?> ExtractColumnValues(WViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.Remains;
        }

        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => WViewModel.GetColumns(isAdmin);

        protected override WViewModel Parse(ToDoWare model) => WViewModel.Parse(model);

        protected override bool TryParse(DataGridViewRow row, out WViewModel viewModel)
            => WViewModel.TryParse(row, out viewModel);
    }
}
