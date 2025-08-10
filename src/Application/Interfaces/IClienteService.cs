using Application.DTOs;

namespace Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(long id);
    Task<long> CreateAsync(ClienteDto dto);
    Task<bool> UpdateAsync(long id, ClienteDto dto);
    Task<bool> DeleteAsync(long id);
}
