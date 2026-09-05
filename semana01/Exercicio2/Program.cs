using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é a sua porcentagem no curso? ");
        string entrada = Console.ReadLine();
        int porcentagem = int.Parse(entrada);

        string letra = "";
        string sinal = "";

        if (porcentagem >= 90)
        {
            letra = "A";
        }
        else if (porcentagem >= 80)
        {
            letra = "B";
        }
        else if (porcentagem >= 70)
        {
            letra = "C";
        }
        else if (porcentagem >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        int ultimoDigito = porcentagem % 10;

        if (ultimoDigito >= 7)
        {
            sinal = "+";
        }
        else if (ultimoDigito < 3)
        {
            sinal = "-";
        }
        else
        {
            sinal = "";
        }

        if (letra == "A" && sinal == "+")
        {
            sinal = "";
        }

        if (letra == "F")
        {
            sinal = "";
        }

        Console.WriteLine($"Sua nota conceitual é: {letra}{sinal}");

        if (porcentagem >= 70)
        {
            Console.WriteLine("Parabéns! Você foi aprovado no curso!");
        }
        else
        {
            Console.WriteLine("Não desanime! Continue se esforçando para a próxima vez.");
        }
    }
}