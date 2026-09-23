using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Pedido 1: cliente nos EUA (frete de $5)
        Endereco endereco1 = new Endereco("123 Main St", "Boise", "ID", "EUA");
        Cliente cliente1 = new Cliente("John Smith", endereco1);
        Pedido pedido1 = new Pedido(cliente1);
        pedido1.AdicionarProduto(new Produto("Camiseta", "SKU001", 19.99, 2));
        pedido1.AdicionarProduto(new Produto("Boné", "SKU002", 14.50, 1));
        pedido1.AdicionarProduto(new Produto("Meias", "SKU003", 5.99, 3));

        // Pedido 2: cliente fora dos EUA (frete de $35)
        Endereco endereco2 = new Endereco("Rua das Flores, 200", "São Paulo", "SP", "Brasil");
        Cliente cliente2 = new Cliente("Maria Silva", endereco2);
        Pedido pedido2 = new Pedido(cliente2);
        pedido2.AdicionarProduto(new Produto("Fone de Ouvido", "SKU004", 49.90, 1));
        pedido2.AdicionarProduto(new Produto("Carregador", "SKU005", 22.00, 2));

        ExibirPedido(pedido1);
        Console.WriteLine("----------------------------------------");
        ExibirPedido(pedido2);
    }

    static void ExibirPedido(Pedido pedido)
    {
        Console.WriteLine("Etiqueta de Embalagem:");
        Console.WriteLine(pedido.ObterEtiquetaEmbalagem());
        Console.WriteLine();

        Console.WriteLine("Etiqueta de Envio:");
        Console.WriteLine(pedido.ObterEtiquetaEnvio());
        Console.WriteLine();

        string precoFormatado = pedido.CalcularCustoTotal().ToString("F2", CultureInfo.InvariantCulture);
        Console.WriteLine($"Preço Total: ${precoFormatado}");
    }
}
