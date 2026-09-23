using System;

class Endereco
{
    private string _rua;
    private string _cidade;
    private string _estado;
    private string _pais;

    public Endereco(string rua, string cidade, string estado, string pais)
    {
        _rua = rua;
        _cidade = cidade;
        _estado = estado;
        _pais = pais;
    }

    // Verifica se o endereço é nos EUA, aceitando "EUA" ou "USA"
    public bool EstaNosEUA()
    {
        return _pais.Trim().Equals("EUA", StringComparison.OrdinalIgnoreCase) ||
               _pais.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string ObterEnderecoCompleto()
    {
        return $"{_rua}\n{_cidade}, {_estado}\n{_pais}";
    }
}
