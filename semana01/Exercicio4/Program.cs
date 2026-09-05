using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();
        int numeroDigitado = -1;

        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        while (numeroDigitado != 0)
        {
            Console.Write("Insira o número: ");
            numeroDigitado = int.Parse(Console.ReadLine());

            if (numeroDigitado != 0)
            {
                numeros.Add(numeroDigitado);
            }
        }

        int soma = 0;
        int maior = numeros[0];
        int menorPositivo = int.MaxValue;

        foreach (int num in numeros)
        {
            soma += num;

            if (num > maior)
            {
                maior = num;
            }

            if (num > 0 && num < menorPositivo)
            {
                menorPositivo = num;
            }
        }

        double media = (double)soma / numeros.Count;

        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");

        if (menorPositivo != int.MaxValue)
        {
            Console.WriteLine($"O menor número positivo é: {menorPositivo}");
        }

        numeros.Sort();

        Console.WriteLine("A lista reordenada é:");
        foreach (int num in numeros)
        {
            Console.WriteLine(num);
        }
    }
}