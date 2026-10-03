using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private const int SegundosPorPergunta = 10;

    private List<string> _sugestoes = new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    };

    private List<string> _perguntas = new List<string>
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo parecido antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou essa ocasião diferente de outras em que você não teve tanto sucesso?",
        "Qual é a sua parte favorita dessa experiência?",
        "O que você pode aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo com essa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    };

    // Itens ainda não exibidos (veja Atividade.ObterAleatorioSemRepetir).
    private List<string> _sugestoesRestantes = new List<string>();
    private List<string> _perguntasRestantes = new List<string>();

    public AtividadeDeReflexao()
        : base("Atividade de Reflexão",
               "Esta atividade vai ajudar você a refletir sobre momentos da sua vida em que demonstrou força e resiliência. " +
               "Isso ajudará você a reconhecer o poder que tem e como usá-lo em outros aspectos da sua vida.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Considere a seguinte sugestão:");
        Console.WriteLine();
        Console.WriteLine($" --- {ObterAleatorioSemRepetir(_sugestoes, _sugestoesRestantes)} ---");
        Console.WriteLine();
        Console.WriteLine("Quando tiver algo em mente, pressione Enter para continuar.");
        Console.ReadLine();

        Console.WriteLine("Agora reflita sobre cada uma das perguntas a seguir em relação a essa experiência.");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.Clear();

        // O cronômetro só começa quando o usuário está pronto, para que ele tenha a duração completa.
        DateTime horaFinal = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < horaFinal)
        {
            Console.Write($"> {ObterAleatorioSemRepetir(_perguntas, _perguntasRestantes)} ");
            ExibirSpinner(SegundosPorPergunta);
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}
