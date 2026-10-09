// Meta recorrente que nunca termina e pontua toda vez que é registrada
// (ex: ler as escrituras).
public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override int RegistrarEvento()
    {
        return ObterPontos();
    }

    public override bool EstaCompleta()
    {
        return false;
    }

    public override string ObterRepresentacaoTexto()
    {
        return $"MetaEterna:{ObterCamposBase()}";
    }
}
