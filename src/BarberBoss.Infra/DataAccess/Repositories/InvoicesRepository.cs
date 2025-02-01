using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Invoices;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infra.DataAccess.Repositories;
internal class InvoicesRepository : IInvoicesRepository
{
    private readonly BarberBossDbContext _context;

    public InvoicesRepository(BarberBossDbContext context)
    {
        _context = context;
    }

    public async Task Add(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
    }

    public async Task<List<Invoice>> GetAll()
    {
        return await _context.Invoices.AsNoTracking().ToListAsync();
    }
}
