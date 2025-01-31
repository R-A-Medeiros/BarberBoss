using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoices;
public interface IInvoicesRepository
{
    Task<List<Invoice>> GetAll();
}
