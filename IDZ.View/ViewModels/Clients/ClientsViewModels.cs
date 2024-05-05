using IDZ.Domain.Abstract;
using IDZ.Domain.Lists;
using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Sewer;
namespace IDZ.View.ViewModels.Clients
{
    public sealed class ClientsViewModels:GridViewModel<ToDoClient, CViewModel>
    {
        public ClientsViewModels() : base(new ListRepository())
        {
        }
        public override void UpdateFromViewModel(IRepository<ToDoClient> _r, CViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.NameClient = viewModel.NameClient;
                existingModel.AddressClient = viewModel.AddressClient;
                existingModel.NumClient = viewModel.NumClient;
                existingModel.Size = viewModel.Size;

                _r.Update(existingModel);
            }
        }
        protected override CViewModel Parse(ToDoClient model)=>CViewModel.Parse(model);

        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => CViewModel.GetColumns(isAdmin);

        protected override IEnumerable<object?> ExtractColumnValues(CViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.NameClient;
            yield return viewModel.AddressClient;
            yield return viewModel.NumClient;
            yield return viewModel.Size;
        }
        protected override bool TryParse(DataGridViewRow row, out CViewModel viewModel)
            =>CViewModel.TryParse(row, out viewModel);

        protected override bool Equals(CViewModel originalViewModel, CViewModel viewModel)
            =>originalViewModel.Equals(viewModel.NameClient, viewModel.NumClient);
    }
}
