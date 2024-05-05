using IDZ.Domain.Abstract;
using IDZ.Domain.Order;
using IDZ.Persistense.Repositories;

namespace IDZ.View.ViewModels.Order
{
    public sealed class OrderViewModel : GridViewModel<ToDoOrder, OViewModel>
    {
        public OrderViewModel() : base(new ORepository())
        {
        }

        public override void UpdateFromViewModel(IRepository<ToDoOrder> _r, OViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.Id_Sewer = viewModel.Id_Sewer;
                existingModel.DataDoPlan = viewModel.DataDoPlan;
                existingModel.DataDoReal = viewModel.DataDoReal;
                existingModel.Ready = viewModel.Ready;

                _r.Update(existingModel);
            }
        }

        protected override bool Equals(OViewModel originalViewModel, OViewModel viewModel)
            => Equals(originalViewModel.DataTake, viewModel.DataTake) && originalViewModel.Id_Client.Equals(viewModel.Id_Client);

        protected override IEnumerable<object?> ExtractColumnValues(OViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.Id_Client;
            yield return viewModel.Id_Model;
            yield return viewModel.Id_Fabric;
            yield return viewModel.Id_Sewer;
            yield return viewModel.DataTake;
            yield return viewModel.DataDoPlan;
            yield return viewModel.DataDoReal;
            yield return viewModel.CostFabric;
            yield return viewModel.CostOrder;
            yield return viewModel.ExpenseFabricReal;
            yield return viewModel.Ready;
        }

        protected override DataGridViewColumn[] GetColumns(bool isAdmin)
            => OViewModel.GetColumns(isAdmin);

        protected override OViewModel Parse(ToDoOrder model) => OViewModel.Parse(model);

        protected override bool TryParse(DataGridViewRow row, out OViewModel viewModel) 
            => OViewModel.TryParse(row, out viewModel);
    }
}
