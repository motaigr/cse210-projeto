// Classe base abstrata: não faz sentido criar uma "meta" genérica,
// apenas metas concretas (MetaSimples, MetaEterna, MetaChecklist).
public abstract class Meta
{
    // Separador usado no arquivo de salvamento.
    public const char Separador = '|';

    private string _nome;
    private string _descricao;
    private int _pontos;

    public Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public string ObterDescricao()
    {
        return _descricao;
    }

    public int ObterPontos()
    {
        return _pontos;
    }

    // Registra um avanço na meta e devolve quantos pontos foram ganhos.
    public abstract int RegistrarEvento();

    // Indica se a meta foi concluída.
    public abstract bool EstaCompleta();

    // Texto exibido na listagem do console, ex: "[X] Correr (Maratona)".
    // As classes derivadas podem acrescentar informações (ex: progresso 2/10).
    public virtual string ObterDetalhes()
    {
        string marcador = EstaCompleta() ? "X" : " ";
        return $"[{marcador}] {_nome} ({_descricao})";
    }

    // Linha que representa a meta no arquivo de texto.
    public abstract string ObterRepresentacaoTexto();

    // Campos comuns a todas as metas, já no formato do arquivo.
    protected string ObterCamposBase()
    {
        return $"{_nome}{Separador}{_descricao}{Separador}{_pontos}";
    }
}
