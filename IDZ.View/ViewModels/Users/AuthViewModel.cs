
using IDZ.Domain.Users;
using IDZ.Persistense.Repositories;

namespace IDZ.View.ViewModels.Users
{
    internal sealed class AuthViewModel
    {
        private readonly IUserRepository _userRepository;
        private TextBox? _nameTextBox;
        private TextBox? _passwordTextBox;
        public AuthViewModel()
        {
            _userRepository=new UserRepository();
        }
        public void Initialize(TextBox nameTextBox, TextBox passwordTextBox)
        {
            _nameTextBox = nameTextBox;
            _passwordTextBox = passwordTextBox;
        }
        public bool TryLogin()
        {
            var user=_userRepository.GetByName(_nameTextBox?.Text ?? string.Empty);
            if(user is null)
                return false;

            var isPasswordCorrect= user.Password==_passwordTextBox?.Text;
            if (isPasswordCorrect)
                Cache.User = user;

            return isPasswordCorrect;
        }
    }
}
