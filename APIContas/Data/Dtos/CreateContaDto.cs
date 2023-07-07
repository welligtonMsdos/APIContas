using System.ComponentModel.DataAnnotations;

namespace APIContas.Data.Dtos;

public class CreateContaDto
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [Display(Name = "Descrição")]
    [MinLength(5, ErrorMessage = "{0} necessário mínimo 5 caracteres")]
    [MaxLength(30, ErrorMessage = "{0} máximo 30 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [Range(1, 50000, ErrorMessage = "{0} precisa estar entre R$ 1,00 e R$ 50.000,00")]
    public decimal Valor { get; set; }
}
