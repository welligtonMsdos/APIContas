namespace APIContas.Data.Dtos;

public class ReadContaDto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateTime HoraConsultada { get; set; } = DateTime.Now;
}
