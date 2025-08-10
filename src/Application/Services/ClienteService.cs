using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ClienteService(IClienteRepository repo) : IClienteService
{
    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var list = await repo.GetAllAsync();
        return list.Select(x => new ClienteDto(x.Id, x.Nome, x.Email, x.DataCadastro));
    }

    public async Task<ClienteDto?> GetByIdAsync(long id)
    {
        var e = await repo.GetByIdAsync(id);
        return e is null ? null : new ClienteDto(e.Id, e.Nome, e.Email, e.DataCadastro);
    }

    public async Task<long> CreateAsync(ClienteDto dto)
    {
        var e = new Cliente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            DataCadastro = dto.DataCadastro == default ? DateTime.UtcNow : dto.DataCadastro
        };
        await repo.AddAsync(e);
        await repo.SaveChangesAsync();
        return e.Id;
    }

    public async Task<bool> UpdateAsync(long id, ClienteDto dto)
    {
        var e = await repo.GetByIdAsync(id);
        if (e is null) return false;
        e.Nome = dto.Nome;
        e.Email = dto.Email;
        e.DataCadastro = dto.DataCadastro == default ? e.DataCadastro : dto.DataCadastro;
        repo.Update(e);
        await repo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var e = await repo.GetByIdAsync(id);
        if (e is null) return false;
        repo.Remove(e);
        await repo.SaveChangesAsync();
        return true;
    }
}
