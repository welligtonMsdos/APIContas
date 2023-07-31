namespace APIContas.Data.Dtos.Conta;

public record CreateContaDto(string Descricao, int mes, decimal Valor);
