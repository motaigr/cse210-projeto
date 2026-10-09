// Meta de conclusão única (ex: correr uma maratona).
public class MetaSimples : Meta
{
    private bool _concluida;

    public MetaSimples(string nome, string descricao, int pontos, bool concluida = false)
        : base(nome, descricao, pontos)
    {
        _concluida = concluida;
    }

    public override int RegistrarEvento()
    {
        // Uma meta simples só pontua na primeira vez.
        if (_concluida)
        {
            return 0;
        }

        _concluida = true;
        return ObterPontos();
    }

    public override bool EstaCompleta()
    {
        return _concluida;
    }

    public override string ObterRepresentacaoTexto()
    {
        return $"MetaSimples:{ObterCamposBase()}{Separador}{_concluida}";
    }
}
