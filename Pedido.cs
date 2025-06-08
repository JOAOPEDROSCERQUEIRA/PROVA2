public class Pedido
{
    public Guid Id { get; private set; }
    public Cliente Cliente { get; private set; }
    public List<ItemPedido> Itens { get; private set; }
    public DateTime DataPedido { get; private set; }
    public decimal ValorTotal { get; private set; }

    public Pedido(Cliente cliente, List<ItemPedido> itens)
    {
        if (cliente == null)
            throw new ArgumentException("Cliente é obrigatório.");

        if (itens == null || !itens.Any())
            throw new ArgumentException("O pedido deve conter ao menos um item.");

        Id = Guid.NewGuid();
        Cliente = cliente;
        Itens = itens;
        DataPedido = DateTime.Now;
        ValorTotal = CalcularValorTotal();
    }

    private decimal CalcularValorTotal()
    {
        return Itens.Sum(item => item.Subtotal); // Sum é um método que soma os valores retornados por uma função para cada item da lista.
    }
}
