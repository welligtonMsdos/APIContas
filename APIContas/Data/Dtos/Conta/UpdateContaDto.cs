namespace APIContas.Data.Dtos.Conta;

public record UpdateContaDto(int id, string Descricao, decimal Valor, int Mes);
