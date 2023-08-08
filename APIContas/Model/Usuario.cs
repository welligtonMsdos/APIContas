using System.ComponentModel.DataAnnotations;

namespace APIContas.Model;

public class Usuario
{    
    public int Id { get; set; }    
    public string Nome { get; set; }

    [DataType(DataType.Password)]
    public string Senha { get; set; }
    public bool Ativo { get; set; }     
    public int PerfilId { get; set; }
    public Perfil? Perfil { get; init; }
}
