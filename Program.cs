using System;
using System.Collections.Generic;

// Classe principal do programa
class Program
{
    // Método principal (ponto de entrada do programa)
    static void Main(string[] args)
    {
        // Criar repositório de pedidos 
        IPedidoRepository pedidoRepository = new PedidoRepository();

        // Criar produtos com nome, preço e categoria
        Produto produto1 = new Produto("Smartphone", 1500m, "Eletrônicos");
        Produto produto2 = new Produto("Camiseta", 50m, "Vestuário");
        Produto produto3 = new Produto("Notebook", 3000m, "Eletrônicos");

        // Criar cliente com nome, email e CPF
        Cliente cliente = new Cliente("Maria Silva", "maria@email.com", "12345678901");

        // Criar itens do pedido (produto + quantidade)
        ItemPedido item1 = new ItemPedido(produto1, 1);
        ItemPedido item2 = new ItemPedido(produto2, 3);
        ItemPedido item3 = new ItemPedido(produto3, 2);

        // Criar lista de itens para o pedido
        List<ItemPedido> itensPedido = new List<ItemPedido> { item1, item2, item3 };

        // Criar estratégia de desconto: 10% para produtos da categoria "Eletrônicos"
        IDescontoStrategy desconto = new DescontoPorCategoria("Eletrônicos", 0.10m);

        // Criar fábrica de pedidos passando a estratégia de desconto
        PedidoFactory pedidoFactory = new PedidoFactory(desconto);

        // Criar um pedido usando a fábrica, passando cliente e itens
        Pedido pedido = pedidoFactory.CriarPedido(cliente, itensPedido);

        // Adicionar o pedido ao repositório (salvar na "base de dados" em memória)
        pedidoRepository.Adicionar(pedido);

        // Exibir relatório de todos os pedidos cadastrados
        Console.WriteLine("----- Relatório de Pedidos -----");
        foreach (var p in pedidoRepository.ObterTodos()) // Para cada pedido no repositório
        {
            Console.WriteLine($"Pedido: {p.Id}");                    // Exibe ID do pedido
            Console.WriteLine($"Cliente: {p.Cliente.Nome}");         // Exibe nome do cliente
            Console.WriteLine($"Data: {p.DataPedido}");              // Exibe data do pedido
            Console.WriteLine("Itens:");

            // Exibe cada item do pedido
            foreach (var item in p.Itens)
            {
                Console.WriteLine($"- {item.Produto.Nome} x {item.Quantidade} = R$ {item.Subtotal}");
            }

            // Exibe o valor total do pedido com desconto
            Console.WriteLine($"Valor Total com desconto: R$ {p.ValorTotal}");
            Console.WriteLine("-------------------------------"); // Linha de separação
        }
    }
}
