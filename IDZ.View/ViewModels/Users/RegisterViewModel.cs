
using IDZ.Domain.Users;
using IDZ.Persistense.Repositories;

namespace IDZ.View.ViewModels.Users
{
    internal sealed class RegisterViewModel
    {
        private readonly IUserRepository _userRepository;
        private TextBox? _nameTextBox;
        private TextBox? _passwordTextBox;
        public RegisterViewModel()
        {
            _userRepository = new UserRepository();
        }
        public void Initialize(TextBox nameTextBox, TextBox passwordTextBox)
        {
            _nameTextBox = nameTextBox;
            _passwordTextBox = passwordTextBox;
        }
        public bool TryRegister()
        {
            if(!Validate())
                return false;

            var user = _userRepository.GetByName(_nameTextBox?.Text ?? string.Empty);
            if (user is not null)
                return false;

            _userRepository.Add(new User
            {
                Name = _nameTextBox!.Text,
                Password = _passwordTextBox!.Text
            });
            return true;
        }
        private bool Validate()
        {
            if(string.IsNullOrWhiteSpace(_passwordTextBox?.Text)) 
                return false;

            if(string.IsNullOrWhiteSpace(_nameTextBox?.Text)) 
                return false;

            if(_nameTextBox.TextLength<3)
                return false;

            if(_passwordTextBox.TextLength<3)
                return false;

            return true;
        }
    }
}
