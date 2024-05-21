namespace Infraestructure.Models;

public partial class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public partial class Client
{
    public Client()
    {
        this.Id = 0;
        this.Name = string.Empty;
        this.Email = string.Empty;
    }
}