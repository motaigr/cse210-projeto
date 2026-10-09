// Classe base abstrata: não faz sentido criar uma "figura" genérica,
// apenas figuras concretas (Quadrado, Retangulo, Circulo).
public abstract class Figura
{
    private string _cor;

    public Figura(string cor)
    {
        _cor = cor;
    }

    public string ObterCor()
    {
        return _cor;
    }

    public void DefinirCor(string cor)
    {
        _cor = cor;
    }

    // Cada classe derivada é obrigada a implementar seu próprio cálculo de área.
    public abstract double ObterArea();
}
