using System;

class Program
{
    static void Main(string[] args)
    {
        string jogarNovamente = "sim";

        while (jogarNovamente == "sim")
        {
            Random geradorAleatorio = new Random();
            int numeroMagico = geradorAleatorio.Next(1, 101);
            int palpite = 0;
            int contadorPalpites = 0;

            while (palpite != numeroMagico)
            {
                Console.Write("Qual é o seu palpite? ");
                palpite = int.Parse(Console.ReadLine());
                contadorPalpites++;

                if (palpite > numeroMagico)
                {
                    Console.WriteLine("Mais baixo");
                }
                else if (palpite < numeroMagico)
                {
                    Console.WriteLine("Mais alto");
                }
                else
                {
                    Console.WriteLine("Você adivinhou!");
                }
            }

            Console.WriteLine($"Você precisou de {contadorPalpites} palpites.");
            Console.Write("Você deseja jogar de novo? (sim/não) ");
            jogarNovamente = Console.ReadLine().ToLower();
        }
    }
}