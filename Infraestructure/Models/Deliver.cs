namespace Infraestructure.Models;

public partial class Deliver
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
}