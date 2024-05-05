using IDZ.Domain.Fabric;
using IDZ.Domain.Photo;
using IDZ.Domain.Recommend;
using IDZ.Persistense.Repositories;
using System.Reflection;

namespace IDZ.View.Controls.ClientsPanels
{
    public sealed class ClientsRecommendPanel:Panel
    {
        private RRepository _repository;

        private List<ToDoRecommend> Rec;

        private readonly Button _nextButton;
        private readonly Button _previousButton;
        private readonly Button _modelButton;
        private readonly Button _fabricButton;
        private readonly Button _home;

        private readonly Label _reclabel;
        private readonly Label _MFLabel;
        private readonly Label _fabricNameLabel;
        private readonly Label _fabricTypeLabel;
        private readonly Label _costLabel;

        private readonly PictureBox _picture;

        public event EventHandler? MoveToModel
        {
            add => _modelButton.Click += value;
            remove => _modelButton.Click -= value;
        }
        public event EventHandler? MoveToFabric
        {
            add => _fabricButton.Click += value;
            remove => _fabricButton.Click -= value;
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
        public ClientsRecommendPanel()
        {
            _repository = new RRepository();

            Rec = _repository.GetAll().ToList();

            _reclabel = ControlsCreator.CreateLabel("Клієнти купували", CC.midX-5*CC.Gap, CC.Gap);
            _MFLabel = ControlsCreator.CreateLabel2("", CC.midX - 6 * CC.Gap, CC.Gap + CC.TextBoxHeight2);

            _picture= ControlsCreator.CreatePictureBox3(CC.Gap, CC.Gap + 2*CC.TextBoxHeight2);

            _fabricNameLabel= ControlsCreator.CreateLabel2("", 2*CC.Gap+CC.PictureBoxWidth3, CC.Gap + 4*CC.TextBoxHeight2);
            _fabricTypeLabel= ControlsCreator.CreateLabel2("", 2 * CC.Gap + CC.PictureBoxWidth3, CC.Gap + 5 * CC.TextBoxHeight2);
            _costLabel= ControlsCreator.CreateLabel2("", 2 * CC.Gap + CC.PictureBoxWidth3, CC.Gap + 6 * CC.TextBoxHeight2);

            _nextButton = ControlsCreator.CreateButton3("->", 4*CC.Gap+CC.PictureBoxWidth3+CC.ButtonWidth2, CC.Gap + 9 * CC.TextBoxHeight2);
            _previousButton = ControlsCreator.CreateButton3("<-", 4 * CC.Gap + CC.PictureBoxWidth3 + CC.ButtonWidth2, CC.Gap + 10 * CC.TextBoxHeight2);
            _home = ControlsCreator.CreateButton3("Home", 2*CC.Gap, 7 * CC.Gap + 11 * CC.TextBoxHeight2);
            _modelButton = ControlsCreator.CreateButton3("Моделі", 5 * CC.Gap + CC.ButtonWidth3, 7 * CC.Gap + 11 * CC.TextBoxHeight2);
            _fabricButton = ControlsCreator.CreateButton3("Тканини", 8 * CC.Gap + 2*CC.ButtonWidth3, 7 * CC.Gap + 11 * CC.TextBoxHeight2);

            InitializeComponent();

            UpdatePageData();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Controls.Add(_reclabel);
            Controls.Add(_nextButton);
            Controls.Add(_previousButton);
            Controls.Add(_MFLabel);
            Controls.Add(_home);
            Controls.Add(_modelButton);
            Controls.Add(_fabricNameLabel);
            Controls.Add(_picture);
            Controls.Add(_fabricTypeLabel);
            Controls.Add(_costLabel);
            Controls.Add(_fabricButton);

            _nextButton.Click += MoveToNextPage;
            _previousButton.Click += MoveToPreviousPage;

            ResumeLayout(false);
        }
        private void UpdatePageData()
        {
            if (_currentPage >= 0 && _currentPage < Rec.Count)
            {
                var currentRec = Rec[_currentPage];

                var fabricRepository = new FRepository();
                var fabric= fabricRepository.Get(currentRec.Id_Fabric);

                var photoRepository = new PRepository();

                _MFLabel.Text = $"Model N. {currentRec.Id_Model} і Fabric N. {currentRec.Id_Fabric}";
                _fabricNameLabel.Text = $"Назва тканини: {fabric.NameFabric}";
                _fabricTypeLabel.Text = $"Тип тканини: {fabric.Type}";
                _costLabel.Text = $"Вартість тканини для цієї моделі: {currentRec.ExpenseForModel} грн.";

                _picture.Image = photoRepository.GetPhoto(currentRec.Id_Model);

                _nextButton.Visible = _currentPage < Rec.Count - 1;
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
