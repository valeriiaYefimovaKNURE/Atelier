using IDZ.Domain.Abstract;
using IDZ.Domain.Recommend;
using IDZ.Persistense.Repositories;

namespace IDZ.View.ViewModels.Recommend
{
    public sealed class RecommendViewModel : GridViewModel<ToDoRecommend, RViewModel>
    {
        public RecommendViewModel() : base(new RRepository())
        {
        }

        public override void UpdateFromViewModel(IRepository<ToDoRecommend> _r, RViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.Id_Model = viewModel.Id_Model;
                existingModel.ExpenseForModel = viewModel.Expense;

                _r.Update(existingModel);
            }
        }

        protected override bool Equals(RViewModel originalViewModel, RViewModel viewModel) 
            => originalViewModel.Equals(viewModel.Id_Model, viewModel.Id_Fabric);

        protected override IEnumerable<object?> ExtractColumnValues(RViewModel viewModel)
        {
            yield return viewModel.Id_Fabric;
            yield return viewModel.Id_Model;
            yield return viewModel.Expense;
        }

        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => RViewModel.GetColumns(isAdmin);

        protected override RViewModel Parse(ToDoRecommend model) => RViewModel.Parse(model);

        protected override bool TryParse(DataGridViewRow row, out RViewModel viewModel) 
            => RViewModel.TryParse(row, out viewModel);
    }
}
