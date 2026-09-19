using System;

class Program
{
    static void Main(string[] args)
    {
        // Testando os três construtores
        Fracao fracaoUm = new Fracao();
        Fracao fracaoSeis = new Fracao(6);
        Fracao fracaoSeisSetimos = new Fracao(6, 7);

        Console.WriteLine("Testando construtores:");
        Console.WriteLine(fracaoUm.ObterFracaoEmTexto());
        Console.WriteLine(fracaoSeis.ObterFracaoEmTexto());
        Console.WriteLine(fracaoSeisSetimos.ObterFracaoEmTexto());
        Console.WriteLine();

        // Testando getters e setters
        Console.WriteLine("Testando getters e setters:");
        Fracao fracaoTeste = new Fracao(1, 2);
        Console.WriteLine($"Antes: {fracaoTeste.ObterNumerador()}/{fracaoTeste.ObterDenominador()}");

        fracaoTeste.DefinirNumerador(3);
        fracaoTeste.DefinirDenominador(4);
        Console.WriteLine($"Depois: {fracaoTeste.ObterNumerador()}/{fracaoTeste.ObterDenominador()}");
        Console.WriteLine();

        // Exibindo as representações fracionária e decimal
        Console.WriteLine("Representações fracionária e decimal:");
        Fracao[] fracoes = new Fracao[]
        {
            new Fracao(1),
            new Fracao(5),
            new Fracao(3, 4),
            new Fracao(1, 3)
        };

        foreach (Fracao fracao in fracoes)
        {
            Console.WriteLine(fracao.ObterFracaoEmTexto());
            Console.WriteLine(fracao.ObterFracaoEmDecimal());
        }
    }
}
