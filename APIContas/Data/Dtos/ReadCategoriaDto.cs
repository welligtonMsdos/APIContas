namespace APIContas.Data.Dtos;

public class ReadCategoriaDto
{  
    public int Id { get; set; }   
    public string Descricao { get; set; }
    public DateTime HoraConsultada { get; set; } = DateTime.Now;   
}
