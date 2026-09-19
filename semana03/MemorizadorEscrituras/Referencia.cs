public class Referencia
{
    private readonly string _livro;
    private readonly int _capitulo;
    private readonly int _versiculo;
    private readonly int _ultimoVersiculo;

    // Construtor para um único versículo (ex: "João 3:16")
    public Referencia(string livro, int capitulo, int versiculo)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculo = versiculo;
        _ultimoVersiculo = versiculo;
    }

    // Construtor para um intervalo de versículos (ex: "Provérbios 3:5-6")
    public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculo = versiculoInicial;
        _ultimoVersiculo = versiculoFinal;
    }

    public string ObterTextoExibicao()
    {
        if (_ultimoVersiculo > _versiculo)
        {
            return $"{_livro} {_capitulo}:{_versiculo}-{_ultimoVersiculo}";
        }

        return $"{_livro} {_capitulo}:{_versiculo}";
    }
}
