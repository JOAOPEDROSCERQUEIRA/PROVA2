public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public string Categoria { get; private set; }

    public Produto(string nome, decimal preco, string categoria)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do produto é obrigatório.");

        if (preco <= 0)
            throw new ArgumentException("Preço do produto deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(categoria))
            throw new ArgumentException("Categoria do produto é obrigatória.");

        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }
}
