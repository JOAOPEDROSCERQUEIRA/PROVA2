// Interface para criar diferentes tipos de desconto
public interface IDescontoStrategy
{
    // Método que calcula o desconto para um pedido
    decimal CalcularDesconto(Pedido pedido);
}

// Desconto para produtos de uma categoria específica, tipo 10% para "Eletrônicos"
public class DescontoPorCategoria : IDescontoStrategy
{
    private readonly string categoriaDesconto;    // Categoria que recebe desconto
    private readonly decimal percentualDesconto;  // Quanto de desconto (%)

    // Recebe a categoria e o valor do desconto
    public DescontoPorCategoria(string categoriaDesconto, decimal percentualDesconto)
    {
        this.categoriaDesconto = categoriaDesconto;
        this.percentualDesconto = percentualDesconto;
    }

    // Calcula o desconto para o pedido
    public decimal CalcularDesconto(Pedido pedido)
    {
        decimal desconto = 0m;    // Começa sem desconto

        // Para cada item no pedido
        foreach (var item in pedido.Itens)
        {
            // Se o produto for da categoria que tem desconto
            if (item.Produto.Categoria == categoriaDesconto)
            {
                // Adiciona o desconto daquele item (preço x quantidade x %) 
                desconto += item.Subtotal * percentualDesconto;
            }
        }

        return desconto;   // Retorna o total de desconto
    }
}

// Desconto para itens com quantidade grande, tipo 5% se comprar 10 ou mais
public class DescontoPorQuantidade : IDescontoStrategy
{
    private readonly int quantidadeMinima;        // Quantidade mínima para ter desconto
    private readonly decimal percentualDesconto;  // Quanto de desconto (%)

    // Recebe a quantidade mínima e o valor do desconto
    public DescontoPorQuantidade(int quantidadeMinima, decimal percentualDesconto)
    {
        this.quantidadeMinima = quantidadeMinima;
        this.percentualDesconto = percentualDesconto;
    }

    // Calcula o desconto para o pedido
    public decimal CalcularDesconto(Pedido pedido)
    {
        decimal desconto = 0m;    // Começa sem desconto

        // Para cada item no pedido
        foreach (var item in pedido.Itens)
        {
            // Se a quantidade do item for maior ou igual ao mínimo para desconto
            if (item.Quantidade >= quantidadeMinima)
            {
                // Adiciona o desconto daquele item
                desconto += item.Subtotal * percentualDesconto;
            }
        }

        return desconto;   // Retorna o total de desconto
    }
}
