using IDZ.View.Controls.Events;
using IDZ.View.Controls.Helpers;
using IDZ.View.ViewModels.Users;
using CC = IDZ.View.Controls.CC;
namespace IDZ.View.Controls.MainPanels
{
    public sealed class AuthorizationPanel : Panel
    {
        private static readonly object loginEventKey = new();

        private readonly TextBox _loginTextBox;
        private readonly TextBox _passwordTextBox;
        private readonly Button _logInButton;
        private readonly Button _home;

        public event LoginEventHandler? LogIn
        {
            add => Events.AddHandler(loginEventKey, value);
            remove => Events.RemoveHandler(loginEventKey, value);
        }
        public event EventHandler? MoveToHomeClick
        {
            add => _home.Click += value;
            remove => _home.Click -= value;
        }
        private readonly AuthViewModel _authViewModel;

        
        public AuthorizationPanel()
        {
            _loginTextBox = ControlsCreator.CreateTextBox("Login", CC.midX-CC.Gap, CC.midY - 2*CC.TextBoxHeight+3*CC.Gap);
            _passwordTextBox = ControlsCreator.CreateTextBox("Password", CC.midX-CC.Gap, CC.midY- CC.TextBoxHeight);
            _logInButton = ControlsCreator.CreateButton3("Log In", CC.midX + 2 * CC.Gap, PositionCalculator.CalculateY(6 * CC.Gap, _loginTextBox, _passwordTextBox,_loginTextBox));
            _home = ControlsCreator.CreateButton3("Back", CC.Gap, PositionCalculator.CalculateY(17* CC.Gap, _loginTextBox, _passwordTextBox));

            _authViewModel = new AuthViewModel();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            _authViewModel.Initialize(_loginTextBox, _passwordTextBox);

            _logInButton.Click += OnLoginClicked;

            Controls.Add(_loginTextBox);
            Controls.Add(_passwordTextBox);
            Controls.Add(_logInButton);
            Controls.Add( _home);
            ResumeLayout();
        }

        private void OnLoginClicked(object? sender, EventArgs e)
        {
            if (!_authViewModel.TryLogin())
            {
                MessageBox.Show("Auth error", "Invalid login or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var args = new LoginEventArgs
            {
                UserName = _loginTextBox.Text,
                Password = _passwordTextBox.Text,
            };

            var handler = Events[loginEventKey] as LoginEventHandler;
            handler?.Invoke(sender, args);

        }
    }
}
