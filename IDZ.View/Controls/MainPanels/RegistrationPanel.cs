using IDZ.View.Controls.Events;
using IDZ.View.Controls.Helpers;
using IDZ.View.ViewModels.Users;
using CC = IDZ.View.Controls.CC;
namespace IDZ.View.Controls.MainPanels
{
    public sealed class RegistrationPanel : Panel
    {
        private static readonly object regEventKey = new();

        private readonly Label label;
        private readonly TextBox _loginTextBox;
        private readonly TextBox _passwordTextBox;
        private readonly Button _regButton;
        private readonly Button _home;

        public event LoginEventHandler? RegIn
        {
            add => Events.AddHandler(regEventKey, value);
            remove => Events.RemoveHandler(regEventKey, value);
        }
        public event EventHandler? MoveToHomeClick
        {
            add => _home.Click += value;
            remove => _home.Click -= value;
        }
        private readonly RegisterViewModel _regViewModel;
        public RegistrationPanel()
        {
            label = ControlsCreator.CreateLabel("Welcome!", CC.midX+2*CC.Gap, PositionCalculator.CalculateY(8*CC.Gap));
            _loginTextBox = ControlsCreator.CreateTextBox("Login", CC.midX - CC.Gap, CC.midY - 2 * CC.TextBoxHeight + 3 * CC.Gap);
            _passwordTextBox = ControlsCreator.CreateTextBox("Password", CC.midX - CC.Gap, CC.midY - CC.TextBoxHeight);
            _regButton = ControlsCreator.CreateButton3("Sign in", CC.midX+ 2 * CC.Gap, PositionCalculator.CalculateY(6*CC.Gap,_loginTextBox, _passwordTextBox, _loginTextBox));
            _home = ControlsCreator.CreateButton3("Back", CC.Gap, PositionCalculator.CalculateY(17 * CC.Gap, _loginTextBox, _passwordTextBox));

            _regViewModel = new RegisterViewModel();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            _regViewModel.Initialize(_loginTextBox, _passwordTextBox);

            _regButton.Click += OnRegClicked;

            Controls.Add(label);
            Controls.Add(_loginTextBox);
            Controls.Add(_passwordTextBox);
            Controls.Add(_regButton);
            Controls.Add(_home);

            ResumeLayout();
        }

        private void OnRegClicked(object? sender, EventArgs e)
        {
            if (!_regViewModel.TryRegister())
            {
                MessageBox.Show("Registration error", "Maybe you are registered already.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var args = new LoginEventArgs
            {
                UserName = _loginTextBox.Text,
                Password = _passwordTextBox.Text,
            };

            var handler = Events[regEventKey] as LoginEventHandler;
            handler?.Invoke(sender, args);
        }
    }
}
