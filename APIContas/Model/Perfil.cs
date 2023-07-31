using System.ComponentModel.DataAnnotations;

namespace APIContas.Model;

public class Perfil
{
    [Key]
    [Required(ErrorMessage = "{0} é obrigatório")]
    public int Id { get; set; }  

    [Required(ErrorMessage = "{0} é obrigatório")]
    [Display(Name = "Perfil")]
    [MinLength(5, ErrorMessage = "{0} necessário mínimo 3 caracteres")]
    [MaxLength(30, ErrorMessage = "{0} máximo 30 caracteres")]
    public string Descricao { get; set; }

    public bool Ativo { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }
}
