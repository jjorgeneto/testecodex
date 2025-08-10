namespace Application.DTOs;

public record ClienteDto(
    long Id,
    string Nome,
    string Email,
    DateTime DataCadastro
);
