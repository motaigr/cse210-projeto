class Comentario
{
    private string _nome;
    private string _texto;

    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }

    public string ObterTextoFormatado()
    {
        return $"{_nome}: {_texto}";
    }
}
