namespace APIContas.Model;

public class Perfil
{
    public int Id { get; set; }      
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}
