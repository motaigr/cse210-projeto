using System;

class Program
{
    static void Main(string[] args)
    {
        ExibirBoasVindas();
        string nome = PerguntarNomeUsuario();
        int numeroFavorito = PerguntarNumeroFavorito();
        int quadrado = ElevarAoQuadrado(numeroFavorito);
        ExibirResultado(nome, quadrado);
    }

    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        return Console.ReadLine();
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        string entrada = Console.ReadLine();
        return int.Parse(entrada);
    }

    static int ElevarAoQuadrado(int numero)
    {
        return numero * numero;
    }

    static void ExibirResultado(string nome, int quadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {quadrado}");
    }
}