public class Circulo : Figura
{
    private double _raio;

    public Circulo(string cor, double raio) : base(cor)
    {
        _raio = raio;
    }

    // Área do círculo: π * r²
    public override double ObterArea()
    {
        return Math.PI * _raio * _raio;
    }
}
