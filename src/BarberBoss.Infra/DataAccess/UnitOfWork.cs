using BarberBoss.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Infra.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly BarberBossDbContext _context;

    public UnitOfWork(BarberBossDbContext context)
    {
        _context = context;
    }
    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
