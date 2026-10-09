using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A lista é do tipo base, mas guarda objetos das classes derivadas.
        List<Figura> figuras = new List<Figura>();

        figuras.Add(new Quadrado("Vermelho", 3));
        figuras.Add(new Retangulo("Azul", 4, 5));
        figuras.Add(new Circulo("Verde", 6));

        // Polimorfismo: cada objeto executa sua própria versão de ObterArea().
        foreach (Figura figura in figuras)
        {
            string cor = figura.ObterCor();
            double area = figura.ObterArea();

            Console.WriteLine($"A figura {cor} tem área de {area:F2}.");
        }
    }
}
