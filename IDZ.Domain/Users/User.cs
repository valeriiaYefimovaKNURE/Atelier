using IDZ.Domain.Abstract;

namespace IDZ.Domain.Users
{
    public sealed class User:Pov
    {
        public string Name {  get; set; }=string.Empty;
        public string Password {  get; set; }=string.Empty;
        public string Role { get; set; }=string.Empty;
        public bool isAdmin=>Role.Equals(Roles.Admin);
    }
}
