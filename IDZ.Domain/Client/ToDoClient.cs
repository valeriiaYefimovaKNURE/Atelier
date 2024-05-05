using IDZ.Domain.Abstract;

namespace IDZ.Domain.Lists
{
    public sealed class ToDoClient:Pov
    {
        public int Id_Client { get; set; }
        public string NameClient {  get; set; }=string.Empty;
        public string? AddressClient {  get; set; }
        public string? NumClient {  get; set; }
        public int Size { get; set; }
    }
}
