using IDZ.Domain.Abstract;
using IDZ.Domain.Model;
using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Sewer;
namespace IDZ.View.ViewModels.Model
{
    public sealed class ModelsViewModel : GridViewModel<ToDoModel, MViewModel>
    {
        public ModelsViewModel() : base(new MRepository())
        {
        }

        protected override bool Equals(MViewModel originalViewModel, MViewModel viewModel)
        {
            return true;
        }
        public override void UpdateFromViewModel(IRepository<ToDoModel> _r, MViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.ExpenseFabric = viewModel.ExpenseF;
                existingModel.PlanTime = viewModel.PlanTime;
                existingModel.CostModel = viewModel.CostModel;
                existingModel.AdditionalCost = viewModel.AddCost;

                _r.Update(existingModel);
            }
        }
        protected override IEnumerable<object?> ExtractColumnValues(MViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.ExpenseF;
            yield return viewModel.PlanTime;
            yield return viewModel.CostModel;
            yield return viewModel.AddCost;
        }

        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => MViewModel.GetColumns(isAdmin);

        protected override MViewModel Parse(ToDoModel model) => MViewModel.Parse(model);

        protected override bool TryParse(DataGridViewRow row, out MViewModel viewModel)
            => MViewModel.TryParse(row, out viewModel);
    }
}
