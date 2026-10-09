public class Quadrado : Figura
{
    private double _lado;

    // A cor é repassada para o construtor da classe base.
    public Quadrado(string cor, double lado) : base(cor)
    {
        _lado = lado;
    }

    public override double ObterArea()
    {
        return _lado * _lado;
    }
}
