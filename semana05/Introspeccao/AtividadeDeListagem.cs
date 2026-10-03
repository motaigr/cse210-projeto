using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private List<string> _sugestoes = new List<string>
    {
        "Quem são as pessoas que você valoriza?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou nesta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    private List<string> _sugestoesRestantes = new List<string>();

    public AtividadeDeListagem()
        : base("Atividade de Listagem",
               "Esta atividade vai ajudar você a refletir sobre as coisas boas da sua vida, pedindo que liste " +
               "o máximo de coisas que puder em uma determinada área.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Liste o máximo de respostas que puder para a seguinte sugestão:");
        Console.WriteLine($" --- {ObterAleatorioSemRepetir(_sugestoes, _sugestoesRestantes)} ---");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine();

        List<string> itens = new List<string>();
        DateTime horaFinal = DateTime.Now.AddSeconds(ObterDuracao());

        // ReadLine bloqueia, então o tempo é verificado entre as entradas: um item
        // digitado quando o tempo acaba ainda é aceito ao pressionar Enter.
        while (DateTime.Now < horaFinal)
        {
            Console.Write("> ");
            string entrada = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                itens.Add(entrada.Trim());
            }
        }

        Console.WriteLine($"Você listou {itens.Count} itens!");

        ExibirMensagemFinal();
    }
}
