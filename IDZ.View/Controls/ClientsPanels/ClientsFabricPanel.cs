using IDZ.Domain.Fabric;
using IDZ.Persistense.Repositories;

namespace IDZ.View.Controls.ClientsPanels
{
    public sealed class ClientsFabricPanel:Panel
    {
        private FRepository _repository;
        private List<ToDoFabric> Fabric;

        private readonly Button _nextButton;
        private readonly Button _previousButton;
        private readonly Button _modelsButton;
        private readonly Button _home;

        private readonly Label _Numlabel;
        private readonly Label _nameFabric;
        private readonly Label _type;
        private readonly Label _costMeter;

        private readonly PictureBox _mannequin;
        private readonly PictureBox _santimeter;
        private readonly PictureBox _nitka;
        private readonly PictureBox _scissors;

        public event EventHandler? MoveToModelClientsPanel
        {
            add => _modelsButton.Click += value;
            remove => _modelsButton.Click -= value;
        }
        public event EventHandler? MoveToNext
        {
            add => _nextButton.Click += value;
            remove => _nextButton.Click -= value;
        }
        public event EventHandler? MoveToBack
        {
            add => _previousButton.Click += value;
            remove => _previousButton.Click -= value;
        }
        public event EventHandler? MoveToHomeClick
        {
            add => _home.Click += value;
            remove => _home.Click -= value;
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
        public ClientsFabricPanel()
        {
            _repository = new FRepository();
            Fabric = _repository.GetAll().ToList();

            _Numlabel = ControlsCreator.CreateLabel("", CC.midX, 2 * CC.Gap);
            _nameFabric = ControlsCreator.CreateLabel2("", CC.midX-7*CC.Gap, 5 * CC.Gap + CC.TextBoxHeight2);
            _type = ControlsCreator.CreateLabel2("", CC.midX - 7 * CC.Gap, 5 * CC.Gap + 2 * CC.TextBoxHeight2);
            _costMeter = ControlsCreator.CreateLabel2("", CC.midX - 7 * CC.Gap, 5 * CC.Gap + 3 * CC.TextBoxHeight2);

            _modelsButton = ControlsCreator.CreateButton3("Моделі", 4 * CC.Gap + CC.ButtonWidth3, 2 * CC.Gap + CC.PictureBoxHeight2);
            _nextButton = ControlsCreator.CreateButton3("->", CC.midX, 15 * CC.Gap + 4 * CC.TextBoxHeight2 + CC.ButtonHeight3);
            _previousButton = ControlsCreator.CreateButton3("<-", CC.midX, 17 * CC.Gap + 4 * CC.TextBoxHeight2 + 2 * CC.ButtonHeight3);
            _home = ControlsCreator.CreateButton3("Back", CC.Gap, 2 * CC.Gap + CC.PictureBoxHeight2);

            _mannequin=ControlsCreator.CreatePictureBoxSmall(CC.Gap,CC.midY+CC.ButtonHeight3);
            _mannequin.Image = Properties.Resources.mannequin;

            _santimeter = ControlsCreator.CreatePictureBoxSmall(CC.midX+CC.PictureBoxWidth+CC.Gap, CC.midY + CC.ButtonHeight3+7*CC.Gap);
            _santimeter.Image = Properties.Resources.santimeter;

            _nitka = ControlsCreator.CreatePictureBoxSmall(CC.midX + CC.PictureBoxWidth+10*CC.Gap, CC.midY + CC.ButtonHeight3 + 4* CC.Gap);
            _nitka.Image = Properties.Resources.nitka;

            _scissors = ControlsCreator.CreatePictureBoxSmall(CC.midX + CC.PictureBoxWidth+ 5 * CC.Gap, 0);
            _scissors.Image = Properties.Resources.scissors;

            InitializeComponent();

            UpdatePageData();
        }
        private void InitializeComponent()
        {
            SuspendLayout();

            Controls.Add(_Numlabel);
            Controls.Add(_nameFabric);
            Controls.Add(_type);
            Controls.Add(_costMeter);
            Controls.Add(_modelsButton);
            Controls.Add(_nextButton);
            Controls.Add(_previousButton);
            Controls.Add(_home);
            Controls.Add(_mannequin);
            Controls.Add(_santimeter);
            Controls.Add(_nitka);
            Controls.Add(_scissors);

            _nextButton.Click += MoveToNextPage;
            _previousButton.Click += MoveToPreviousPage;

            ResumeLayout(false);
        }
        private void UpdatePageData()
        {
            if (_currentPage >= 0 && _currentPage < Fabric.Count)
            {
                var currentModel = Fabric[_currentPage];

                _Numlabel.Text = $"Fabric N. {currentModel.Id_Fabric}";
                _nameFabric.Text = $"Назва тканини: {currentModel.NameFabric}";
                _type.Text = $"Тип: {currentModel.Type}";
                _costMeter.Text = $"Ціна за метр: {currentModel.CostForMeter} грн.";

                _nextButton.Visible = _currentPage < Fabric.Count - 1;
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
