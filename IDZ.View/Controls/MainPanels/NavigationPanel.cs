using IDZ.View.Controls.Helpers;
namespace IDZ.View.Controls.MainPanels
{
    public sealed class NavigationPanel : Panel
    {
        private readonly Button _home;
        private readonly Button _logInButton;
        private readonly Button _logOutButton;
        private readonly Button _registerButton;
        private readonly Button _moveToClients;
        private readonly Button _moveToSewer;
        private readonly Button _moveToFabric;
        private readonly Button _moveToModels;
        private readonly Button _moveToPhotos;
        private readonly Button _moveToWare;
        private readonly Button _moveToOrder;

        public event EventHandler? MoveToAuthorization
        {
            add => _logInButton.Click += value;
            remove => _logInButton.Click -= value;
        }
        public event EventHandler? LogOutClick
        {
            add => _logOutButton.Click += value;
            remove => _logOutButton.Click -= value;
        }
        public event EventHandler? MoveToRegistration
        {
            add => _registerButton.Click += value;
            remove => _registerButton.Click -= value;
        }
        public event EventHandler? MoveToClientsClick
        {
            add => _moveToClients.Click += value;
            remove => _moveToClients.Click -= value;
        }
        public event EventHandler? MoveToSewerClick
        {
            add => _moveToSewer.Click += value;
            remove => _moveToSewer.Click -= value;
        }
        public event EventHandler? MoveToFabricClick
        {
            add => _moveToFabric.Click += value;
            remove => _moveToFabric.Click -= value;
        }
        public event EventHandler? MoveToModelsClick
        {
            add => _moveToModels.Click += value;
            remove => _moveToModels.Click -= value;
        }
        public event EventHandler? MoveToPhotoClick
        {
            add => _moveToPhotos.Click += value;
            remove => _moveToPhotos.Click -= value;
        }
        public event EventHandler? MoveToWareClick
        {
            add => _moveToWare.Click += value;
            remove => _moveToWare.Click -= value;
        }
        public event EventHandler? MoveToOrderClick
        {
            add => _moveToOrder.Click += value;
            remove => _moveToOrder.Click -= value;
        }
        public event EventHandler? MoveToHomeClick
        {
            add => _home.Click += value;
            remove => _home.Click -= value;
        }
        public new Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                _logOutButton.Location = new Point(Width - CC.Gap - CC.ButtonWidth, CC.Gap);
                _home.Location = new Point(Width - 2*CC.Gap - 2*CC.ButtonWidth, CC.Gap);
            }
        }
        public NavigationPanel()
        {
            _home = ControlsCreator.CreateButton("Home", Width - CC.Gap - CC.ButtonWidth, CC.Gap, false);
            _logInButton = ControlsCreator.CreateButton("Вхід", CC.Gap, PositionCalculator.CalculateY(CC.Gap));
            _registerButton = ControlsCreator.CreateButton4("Реєстрація", PositionCalculator.CalculateY(CC.Gap * 4, _logInButton), CC.Gap);
            _logOutButton = ControlsCreator.CreateButton("Вийти", Width - CC.Gap - CC.ButtonWidth, CC.Gap, false);
            _moveToClients = ControlsCreator.CreateButton("Клієнти", PositionCalculator.CalculateY(CC.Gap), CC.Gap, false);
            _moveToSewer = ControlsCreator.CreateButton("Кравці", PositionCalculator.CalculateY(CC.Gap, _logInButton,_moveToClients), CC.Gap, false);
            _moveToFabric = ControlsCreator.CreateButton("Тканина", PositionCalculator.CalculateY(CC.Gap, _logInButton, _moveToClients,_moveToSewer,_registerButton), CC.Gap, false);
            _moveToModels = ControlsCreator.CreateButton("Моделі", PositionCalculator.CalculateY(2 * CC.Gap, _logInButton, _moveToClients, _moveToSewer, _registerButton, _moveToFabric), CC.Gap, false);
            _moveToPhotos = ControlsCreator.CreateButton("Фото", PositionCalculator.CalculateY(4*CC.Gap, _logInButton, _moveToClients, _moveToSewer, _registerButton,_moveToFabric), CC.Gap, false);
            _moveToWare = ControlsCreator.CreateButton("Склад", PositionCalculator.CalculateY(6 * CC.Gap, _logInButton, _moveToClients, _moveToSewer, _registerButton, _moveToFabric), CC.Gap, false);
            _moveToOrder= ControlsCreator.CreateButton("Замов.", PositionCalculator.CalculateY(6 * CC.Gap, _logInButton, _moveToClients, _moveToSewer, _registerButton, _moveToFabric,_moveToWare), CC.Gap, false);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            _logOutButton.Click += OnLogOutClicked;

            Controls.Add(_home);
            Controls.Add(_logInButton);
            Controls.Add(_registerButton);
            Controls.Add(_logOutButton);
            Controls.Add(_moveToClients);
            Controls.Add(_moveToSewer);
            Controls.Add(_moveToFabric);
            Controls.Add(_moveToPhotos);
            Controls.Add(_moveToModels);
            Controls.Add( _moveToWare);
            Controls.Add(_moveToOrder);

            ResumeLayout(false);
        }

        private void OnLogOutClicked(object? sender, EventArgs e)
        {
            _home.Visible = false;
            _logInButton.Visible = true;
            _logOutButton.Visible = false;
            _registerButton.Visible = true;
            _moveToClients.Visible = false;
            _moveToSewer.Visible = false;
            _moveToFabric.Visible= false;
            _moveToPhotos.Visible = false;
            _moveToModels.Visible = false;
            _moveToWare.Visible = false;
            _moveToOrder.Visible = false;

            Cache.User = null;
        }

        public void OnLoggedIn(object? sender, EventArgs e)
        {
            _home.Visible = true;
            _logInButton.Visible = false;
            _logOutButton.Visible = true;
            _registerButton.Visible = false;

            if (Cache.User != null)
            {
                bool isAdmin = Cache.User.isAdmin;
                _moveToClients.Visible = isAdmin;
                _moveToSewer.Visible = isAdmin;
                _moveToFabric.Visible = isAdmin;
                _moveToPhotos.Visible = isAdmin;
                _moveToModels.Visible = isAdmin;
                _moveToWare.Visible = isAdmin;
                _moveToOrder.Visible = isAdmin;
            }
        }
    }
}
