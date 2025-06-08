public class Pedido
{
    public Guid Id { get; private set; }                  // Identificador único do pedido
    public Cliente Cliente { get; private set; }          // Cliente que fez o pedido
    public List<ItemPedido> Itens { get; private set; }   // Lista de itens que o pedido contém
    public DateTime DataPedido { get; private set; }      // Data e hora que o pedido foi criado
    public decimal ValorTotal { get; private set; }       // Valor total do pedido, já com desconto aplicado
    private IDescontoStrategy DescontoStrategy { get; set; } // Estratégia para calcular desconto (pode ser nula)

    // Construtor da classe Pedido, que recebe cliente, lista de itens e opcionalmente uma estratégia de desconto
    public Pedido(Cliente cliente, List<ItemPedido> itens, IDescontoStrategy descontoStrategy = null)
    {
        if (cliente == null)                                // Verifica se o cliente foi passado
            throw new ArgumentException("Cliente é obrigatório.");  // Lança erro se não houver cliente

        if (itens == null || !itens.Any())                 // Verifica se há itens no pedido
            throw new ArgumentException("O pedido deve conter ao menos um item."); // Erro se lista vazia

        Id = Guid.NewGuid();                                // Gera um ID único para o pedido
        Cliente = cliente;                                  // Define o cliente do pedido
        Itens = itens;                                      // Define a lista de itens do pedido
        DataPedido = DateTime.Now;                          // Define a data atual como data do pedido
        DescontoStrategy = descontoStrategy;                // Define a estratégia de desconto (pode ser nula)
        ValorTotal = CalcularValorTotal();                  // Calcula o valor total do pedido, com desconto
    }
}
