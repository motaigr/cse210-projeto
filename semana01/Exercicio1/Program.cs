using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, Mundo! Este é o Projeto Exercicio1.");

        Console.WriteLine("Qual é o seu nome?");
        String nome = Console.ReadLine();
        Console.WriteLine("Qual é o seu sobrenome?");
        String sobrenome = Console.ReadLine();

        Console.WriteLine($"Seu nome é {sobrenome}, {nome} {sobrenome}.");
    }
}