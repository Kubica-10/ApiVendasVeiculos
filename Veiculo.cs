public enum StatusVenda
{
    Disponivel,
    Reservado,
    Vendido
}

public class Veiculo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public int Ano { get; set; }
    public decimal Preco { get; set; }
    public string Cor { get; set; } = string.Empty;
    public int Kilometragem { get; set; }
    public StatusVenda Status { get; set; } = StatusVenda.Disponivel;
}