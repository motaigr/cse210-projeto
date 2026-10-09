// Meta que exige N repetições: pontua a cada repetição e dá um bônus
// ao ser concluída (ex: ir ao templo 10 vezes).
public class MetaChecklist : Meta
{
    private int _vezesAlvo;
    private int _bonus;
    private int _vezesRealizadas;

    public MetaChecklist(string nome, string descricao, int pontos, int vezesAlvo, int bonus, int vezesRealizadas = 0)
        : base(nome, descricao, pontos)
    {
        _vezesAlvo = vezesAlvo;
        _bonus = bonus;
        _vezesRealizadas = vezesRealizadas;
    }

    public override int RegistrarEvento()
    {
        if (EstaCompleta())
        {
            return 0;
        }

        _vezesRealizadas++;
        int ganhos = ObterPontos();

        // O bônus é pago apenas na repetição que completa a meta.
        if (EstaCompleta())
        {
            ganhos += _bonus;
        }

        return ganhos;
    }

    public override bool EstaCompleta()
    {
        return _vezesRealizadas >= _vezesAlvo;
    }

    public override string ObterDetalhes()
    {
        return $"{base.ObterDetalhes()} -- Concluída {_vezesRealizadas}/{_vezesAlvo} vezes";
    }

    public override string ObterRepresentacaoTexto()
    {
        return $"MetaChecklist:{ObterCamposBase()}{Separador}{_bonus}{Separador}{_vezesAlvo}{Separador}{_vezesRealizadas}";
    }
}
