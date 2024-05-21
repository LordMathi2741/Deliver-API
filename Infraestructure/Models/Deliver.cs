namespace Infraestructure.Models;

public partial class Deliver
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
}

public partial class Deliver
{
    public Deliver()
    {
        this.Id = 0;
        this.ClientId = 0;
        this.Date = DateTime.Now;
        this.Amount = 0;
    }
}