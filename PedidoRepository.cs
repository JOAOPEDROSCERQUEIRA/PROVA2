// Interface do repositório de pedidos
public interface IPedidoRepository
{
    void Adicionar(Pedido pedido);               // Adiciona um pedido à base de dados
    Pedido ObterPorId(Guid id);                  // Busca um pedido específico pelo ID
    IEnumerable<Pedido> ObterTodos();            // Retorna todos os pedidos cadastrados
}

// Implementação do repositório em memória (sem banco de dados real)
public class PedidoRepository : IPedidoRepository
{
    private readonly List<Pedido> _pedidos = new List<Pedido>(); // Lista interna que armazena os pedidos

    // Adiciona um pedido à lista
    public void Adicionar(Pedido pedido)
    {
        if (pedido == null)                                    // Verifica se o pedido é nulo
            throw new ArgumentNullException(nameof(pedido));   // Lança erro se o pedido for inválido

        _pedidos.Add(pedido);                                  // Adiciona o pedido à lista
    }

    // Retorna um pedido específico com base no ID
    public Pedido ObterPorId(Guid id)
    {
        return _pedidos.FirstOrDefault(p => p.Id == id);       // Retorna o primeiro pedido com o ID ou null se não encontrar
    }

    // Retorna todos os pedidos salvos
    public IEnumerable<Pedido> ObterTodos()
    {
        return _pedidos;                                       // Retorna a lista de pedidos
    }
}
