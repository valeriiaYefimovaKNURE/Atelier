using IDZ.Domain.Abstract;
using IDZ.Domain.Lists;
using IDZ.Domain.Photo;
namespace IDZ.View.ViewModels
{
    public abstract class GridViewModel<TPov, TViewModel> 
        where TPov:Pov 
        where TViewModel:ViewModel<TPov>
    {
        private readonly IRepository<TPov> _repository;

        private DataGridView? _view;
        private Button? _saveButton;
        private IReadOnlyCollection<TViewModel>? _originalModels;

        protected GridViewModel(IRepository<TPov> repository)
        {
            _repository = repository;
        }
        public void Initialize(DataGridView view, Button saveButton)
        {
            _view = view;
            _saveButton = saveButton;

            _saveButton.Click += OnSaveButtonClicked;

            if (_view == null)
                throw new ArgumentNullException(nameof(view));

            _view.AutoGenerateColumns = false;


            var models = _repository.GetAll();
            _originalModels = models.Select(Parse).ToList();

            UpdateGrid();

            _view.ContextMenuStrip = new ContextMenuStrip();
            _view.ContextMenuStrip.Items.Add("Add", null, OnAddCliked);
            _view.ContextMenuStrip.Items.Add("Delete", null, OnDeleteCliked);
            _view.ContextMenuStrip.Items.Add("Update", null, OnUpdateCliked);

            _view.Update();
        }
        public void UpdateGrid()
        {
            if(_view is null) return;

            _view.Columns.Clear();
            _view.Columns.AddRange(GetColumns(Cache.User?.isAdmin == true));

            _view.Rows.Clear();
            foreach (var list in _originalModels ?? Enumerable.Empty<TViewModel>())
                _view.Rows.Add(ExtractColumnValues(list).ToArray());

            _view.Update();
        }
        protected abstract TViewModel Parse(TPov model);

        protected abstract DataGridViewColumn[] GetColumns(bool  isAdmin);

        protected abstract IEnumerable<object?> ExtractColumnValues(TViewModel viewModel);
        private void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            CheckViewIsNotNull();
            foreach (var row in _view!.Rows.Cast<DataGridViewRow>())
            {
                if (!TryParse(row, out var viewModel))
                    continue;
                if (viewModel.Id == -1)
                {
                    _repository.Add(viewModel.ToModel());
                    continue;
                }
                var originalViewModel = _originalModels?.FirstOrDefault(l => l.Id == viewModel.Id);

                if (originalViewModel == null)
                    continue;

                if (Equals(originalViewModel, viewModel))
                    continue;

                _repository.Update(viewModel.ToModel());
            }
            _view.Update();
            MessageBox.Show("Saved");
        }
        protected abstract bool TryParse(DataGridViewRow row, out TViewModel viewModel);

        protected abstract bool Equals(TViewModel originalViewModel,TViewModel viewModel);
        private void OnAddCliked(object? sender, EventArgs e)
        {
            CheckViewIsNotNull();

            _view!.Rows.Add();
            _view.Update();
        }
        private void OnDeleteCliked(object? sender, EventArgs e)
        {
            CheckViewIsNotNull();
            var selectedRows = _view!.SelectedRows;
            if (selectedRows == null || selectedRows.Count == 0)
                return;

            foreach (var row in selectedRows.Cast<DataGridViewRow>())
            {
                var idString = row.Cells[ViewModel<TPov>.IdColumnName].Value?.ToString();
                if (!int.TryParse(idString, out var id))
                    continue;

                _view.Rows.Remove(row);
                _repository.Delete(id);
            }
            _view.Update();
        }
        private void OnUpdateCliked(object? sender, EventArgs e)
        {
            var selectedRows = _view!.SelectedRows;
            if (selectedRows == null || selectedRows.Count == 0)
                return;

            foreach (var row in selectedRows.Cast<DataGridViewRow>())
            {
                if (!TryParse(row, out var viewModel))
                    continue;
                var idString = row.Cells[ViewModel<TPov>.IdColumnName].Value?.ToString();
                if (!int.TryParse(idString, out var id))
                    continue;

                var originalModel = _originalModels?.FirstOrDefault(l => l.Id == viewModel.Id);
                if (originalModel == null)
                    continue;

                if (Equals(originalModel, viewModel))
                    continue;

                _repository.Update(originalModel.ToModel());
                UpdateFromViewModel(_repository, originalModel,id);
            }
            _view.Update();
        }
        public abstract void UpdateFromViewModel(IRepository<TPov> _r,TViewModel model, int id);
        private void CheckViewIsNotNull()
        {
            if (_view == null)
                throw new InvalidOperationException("View is not initialized");
        }
    }
}
