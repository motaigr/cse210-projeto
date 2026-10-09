public class Retangulo : Figura
{
    private double _largura;
    private double _altura;

    public Retangulo(string cor, double largura, double altura) : base(cor)
    {
        _largura = largura;
        _altura = altura;
    }

    public override double ObterArea()
    {
        return _largura * _altura;
    }
}
