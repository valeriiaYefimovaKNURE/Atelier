using IDZ.Domain.Abstract;
using IDZ.Domain.Photo;
using IDZ.Domain.Tasks;
using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Sewer;

namespace IDZ.View.ViewModels.Photo
{
    public sealed class PhotoViewModel : GridViewModel<ToDoPhoto, PViewModel>
    {
        public PhotoViewModel() : base(new PRepository())
        {
        }
        public override void UpdateFromViewModel(IRepository<ToDoPhoto> _r, PViewModel viewModel, int id)
        {
            var existingModel = _r.Get(id);

            if (existingModel != null)
            {
                existingModel.Id_Model = viewModel.IdModel;
                existingModel.link = viewModel.link;
                existingModel.Picture = viewModel.Image;

                _r.Update(existingModel);
            }
        }
        protected override bool Equals(PViewModel originalViewModel, PViewModel viewModel)
            => originalViewModel.Equals(viewModel.link, viewModel.IdModel);

        protected override IEnumerable<object?> ExtractColumnValues(PViewModel viewModel)
        {
            yield return viewModel.Id;
            yield return viewModel.IdModel;
            yield return viewModel.link;
            yield return viewModel.Image;
        }
        protected override DataGridViewColumn[] GetColumns(bool isAdmin) => PViewModel.GetColumns(isAdmin);

        protected override PViewModel Parse(ToDoPhoto model) => PViewModel.Parse(model);

        protected override bool TryParse(DataGridViewRow row, out PViewModel viewModel)
            => PViewModel.TryParse(row, out viewModel);
    }
}
