using System.ComponentModel.DataAnnotations;

namespace APIContas.Data.Dtos;

public class UpdatePerfilDto
{
    [Key]
    [Required(ErrorMessage = "{0} é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [Display(Name = "Perfil")]
    [MinLength(5, ErrorMessage = "{0} necessário mínimo 3 caracteres")]
    [MaxLength(30, ErrorMessage = "{0} máximo 30 caracteres")]
    public string Descricao { get; set; }    
}
