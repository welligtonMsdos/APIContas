namespace APIContas.Model;

public class Conta
{    
    public int Id { get; set; }  
    public string Descricao { get; set; }    
    public decimal Valor { get; set; }   
    public int Mes { get; set; }   
    public DateTime DataInclusao { get; set; } = DateTime.Now;
    public bool Ativo { get; set; }
}
