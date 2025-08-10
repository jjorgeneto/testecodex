using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ClienteRepository(AppDbContext ctx) : IClienteRepository
{
    public async Task AddAsync(Cliente entity) => await ctx.Clientes.AddAsync(entity);

    public async Task<IEnumerable<Cliente>> GetAllAsync() => await ctx.Clientes.AsNoTracking().ToListAsync();

    public async Task<Cliente?> GetByIdAsync(object id) => await ctx.Clientes.FindAsync(id) as Cliente;

    public void Remove(Cliente entity) => ctx.Clientes.Remove(entity);

    public void Update(Cliente entity) => ctx.Clientes.Update(entity);

    public async Task<IEnumerable<Cliente>> FindAsync(Expression<Func<Cliente, bool>> predicate) =>
        await ctx.Clientes.AsNoTracking().Where(predicate).ToListAsync();

    public Task<int> SaveChangesAsync() => ctx.SaveChangesAsync();
}
