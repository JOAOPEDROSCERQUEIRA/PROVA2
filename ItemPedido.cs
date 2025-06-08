public class ItemPedido
{
    public Produto Produto { get; private set; } // Produto é do tipo da classe Produto
    public int Quantidade { get; private set; }
    public decimal Subtotal => Produto.Preco * Quantidade;

    public ItemPedido(Produto produto, int quantidade)
    {
        if (produto == null)
            throw new ArgumentException("Produto não pode ser nulo.");

        if (quantidade <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero.");

        Produto = produto;
        Quantidade = quantidade;
    }
}
