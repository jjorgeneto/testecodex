using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public record ClienteDto(
    long Id,
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    string Email,
    DateTime DataCadastro
);
