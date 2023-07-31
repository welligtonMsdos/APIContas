using System.ComponentModel.DataAnnotations;

namespace APIContas.Model;

public class Usuario
{
    [Key]
    [Required(ErrorMessage = "{0} é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]    
    [MinLength(5, ErrorMessage = "{0} necessário mínimo 3 caracteres")]
    [MaxLength(30, ErrorMessage = "{0} máximo 30 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]
    public string Senha { get; set; }

    public bool Ativo { get; set; }

    [Required(ErrorMessage = "Perfil é obrigatório!")]   
    public int PerfilId { get; set; }

    public Perfil Perfil { get; set; }
}
