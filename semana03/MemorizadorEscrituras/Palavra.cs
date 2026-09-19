public class Palavra
{
    private readonly string _texto;
    private bool _estaEscondida;

    public Palavra(string texto)
    {
        _texto = texto;
        _estaEscondida = false;
    }

    public void Esconder()
    {
        _estaEscondida = true;
    }

    public void Exibir()
    {
        _estaEscondida = false;
    }

    public bool EstaEscondida()
    {
        return _estaEscondida;
    }

    public string ObterTextoExibicao()
    {
        if (_estaEscondida)
        {
            return new string('_', _texto.Length);
        }

        return _texto;
    }
}
