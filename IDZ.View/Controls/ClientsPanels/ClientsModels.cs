using IDZ.Domain.Model;
using IDZ.Persistense.Repositories;
using IDZ.View.Controls.Events;

namespace IDZ.View.Controls.ClientsPanels
{
    public sealed class ClientsModels : Panel
    {
        public event EventHandler<ModelEventArgs>? OrderButtonClick;

        private MRepository _repository;
        private PRepository _photoRepository;
        private List<ToDoModel> Models;

        private readonly Button _nextButton;
        private readonly Button _previousButton;
        private readonly Button _orderButton;
        private readonly Button _home;

        private readonly Label _Numlabel;
        private readonly Label _expenseFabric;
        private readonly Label _cost;
        private readonly Label _addCost;

        private readonly PictureBox _picture;

        public event EventHandler? MoveToOrder
        {
            add => _orderButton.Click += value;
            remove => _orderButton.Click -= value;
        }
        public event EventHandler? MoveToHomeClick
        {
            add => _home.Click += value;
            remove => _home.Click -= value;
        }
        public event EventHandler? MoveToOrders
        {
            add
            {
                _orderButton.Click += (sender, args) =>
                {
                    var currentModel = Models[_currentPage];
                    OrderButtonClick?.Invoke(this, new ModelEventArgs(currentModel));

                    value?.Invoke(sender, args);
                };
            }
            remove => _orderButton.Click -= value;
        }
        private int _currentPage = 0;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                UpdatePageData();
            }
        }

        public ClientsModels()
        {
            _repository = new MRepository();
            _photoRepository = new PRepository();
            Models = _repository.GetAll().ToList();

            _Numlabel = ControlsCreator.CreateLabel("", 15 * CC.Gap + CC.PictureBoxWidth2, 2 * CC.Gap);
            _picture = ControlsCreator.CreatePictureBox2(CC.Gap, CC.Gap);
            _expenseFabric = ControlsCreator.CreateLabel2("", 3 * CC.Gap + CC.PictureBoxWidth2, 5 * CC.Gap + CC.TextBoxHeight2);
            _cost = ControlsCreator.CreateLabel2("", 3 * CC.Gap + CC.PictureBoxWidth2, 5 * CC.Gap + 2 * CC.TextBoxHeight2);
            _addCost = ControlsCreator.CreateLabel2("", 3 * CC.Gap + CC.PictureBoxWidth2, 5 * CC.Gap + 3 * CC.TextBoxHeight2);
            _orderButton = ControlsCreator.CreateButton3("Замовити", 16 * CC.Gap + CC.PictureBoxWidth2, 13 * CC.Gap + 4 * CC.TextBoxHeight2);
            _nextButton = ControlsCreator.CreateButton3("->", 16 * CC.Gap + CC.PictureBoxWidth2, 15 * CC.Gap + 4 * CC.TextBoxHeight2 + CC.ButtonHeight3);
            _previousButton = ControlsCreator.CreateButton3("<-", 16 * CC.Gap + CC.PictureBoxWidth2, 17 * CC.Gap + 4 * CC.TextBoxHeight2 + 2 * CC.ButtonHeight3);
            _home = ControlsCreator.CreateButton3("Back", CC.Gap, 2 * CC.Gap + CC.PictureBoxHeight2);

            InitializeComponent();

            UpdatePageData();
        }
        private void InitializeComponent()
        {
            SuspendLayout();

            Controls.Add(_picture);
            Controls.Add(_Numlabel);
            Controls.Add(_expenseFabric);
            Controls.Add(_cost);
            Controls.Add(_addCost);
            Controls.Add(_orderButton);
            Controls.Add(_nextButton);
            Controls.Add(_previousButton);
            Controls.Add(_home);

            _nextButton.Click += MoveToNextPage;
            _previousButton.Click += MoveToPreviousPage;

            ResumeLayout(false);
        }
        private void UpdatePageData()
        {
            if (_currentPage >= 0 && _currentPage < Models.Count)
            {
                var currentModel = Models[_currentPage];

                _picture.Image = _photoRepository.GetPhoto(currentModel.Id_Model);
                _Numlabel.Text = $"Model N. {currentModel.Id_Model}";
                _expenseFabric.Text = $"Витрати тканини: {currentModel.ExpenseFabric} м.";
                _cost.Text = $"Ціна моделі: {currentModel.CostModel} грн.";
                _addCost.Text = $"Додаткова ціна: {currentModel.AdditionalCost} грн.";

                _nextButton.Visible = _currentPage < Models.Count - 1;
                _previousButton.Visible = _currentPage > 0;
            }
        }
        public void MoveToNextPage(object? sender, EventArgs e)
        {
            CurrentPage++;
        }
        public void MoveToPreviousPage(object? sender, EventArgs e)
        {
            if (CurrentPage > 0)
                CurrentPage--;
        }
    }
}
