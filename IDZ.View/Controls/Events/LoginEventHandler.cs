
namespace IDZ.View.Controls.Events
{
    public delegate void LoginEventHandler(object? sender, LoginEventArgs args);
    public sealed class LoginEventArgs : EventArgs
    {
        public required string UserName { get; init; }
        public required string Password { get; init; }
    }
}
