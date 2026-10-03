public class Tarefa
{
    private string _nomeEstudante;
    private string _topico;

    public Tarefa(string nomeEstudante, string topico)
    {
        _nomeEstudante = nomeEstudante;
        _topico = topico;
    }

    // Getter público para que as classes derivadas acessem o nome do estudante
    // sem expor o atributo diretamente.
    public string ObterNomeEstudante()
    {
        return _nomeEstudante;
    }

    public string ObterResumo()
    {
        return $"{_nomeEstudante} - {_topico}";
    }
}
