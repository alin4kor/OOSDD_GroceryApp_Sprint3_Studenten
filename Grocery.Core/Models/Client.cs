
namespace Grocery.Core.Models
{
    public partial class Client : Model
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Client(int id, string name, string emailAddress, string password) : base(id, name)
        {
            EmailAddress=emailAddress;
            Password=password;
        }
        public Client(string? name, string emailAddress, string passwordHash)
            : base (0, string.IsNullOrWhiteSpace(name) ? "Anoniem" : name) 
        {
            EmailAddress = emailAddress;
            passwordHash = passwordHash;
        }
    }
}
