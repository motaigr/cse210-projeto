using System.Collections.Generic;
using System.Text;

class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double CalcularCustoTotal()
    {
        double total = 0;
        foreach (Produto produto in _produtos)
        {
            total += produto.CalcularCustoTotal();
        }

        // Frete: $5 para clientes nos EUA, $35 para os demais
        total += _cliente.MoraNosEUA() ? 5 : 35;

        return total;
    }

    public string ObterEtiquetaEmbalagem()
    {
        StringBuilder etiqueta = new StringBuilder();
        foreach (Produto produto in _produtos)
        {
            etiqueta.AppendLine($"{produto.GetNome()} (ID: {produto.GetIdProduto()})");
        }

        return etiqueta.ToString().TrimEnd();
    }

    public string ObterEtiquetaEnvio()
    {
        return $"{_cliente.GetNome()}\n{_cliente.GetEndereco().ObterEnderecoCompleto()}";
    }
}
