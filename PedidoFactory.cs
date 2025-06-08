public class PedidoFactory
{
    private readonly IDescontoStrategy _descontoStrategy; // Armazena a estratégia de desconto que será usada na criação do pedido

    // Construtor da fábrica de pedidos, recebe uma estratégia de desconto (opcional)
    public PedidoFactory(IDescontoStrategy descontoStrategy = null)
    {
        _descontoStrategy = descontoStrategy; // Armazena a estratégia recebida para uso futuro
    }

    // Método que cria um novo pedido com base no cliente e itens fornecidos
    public Pedido CriarPedido(Cliente cliente, List<ItemPedido> itens)
    {
        // Aqui pode adicionar regras extras antes da criação, se quiser
        return new Pedido(cliente, itens, _descontoStrategy); // Cria e retorna um novo pedido com a estratégia de desconto aplicada
    }
}