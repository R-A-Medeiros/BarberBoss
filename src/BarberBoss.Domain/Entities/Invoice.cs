using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Entities;
public class Invoice
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }

}
