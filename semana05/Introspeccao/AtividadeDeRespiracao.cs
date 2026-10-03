using System;

public class AtividadeDeRespiracao : Atividade
{
    private const int SegundosInspirando = 4;
    private const int SegundosExpirando = 6;

    public AtividadeDeRespiracao()
        : base("Atividade de Respiração",
               "Esta atividade vai ajudar você a relaxar, guiando sua respiração para dentro e para fora lentamente. " +
               "Limpe sua mente e concentre-se na respiração.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        DateTime horaFinal = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < horaFinal)
        {
            Console.WriteLine();
            Console.Write("Inspire...");
            ExibirContagemRegressiva(SegundosInspirando);
            Console.WriteLine();

            Console.Write("Agora expire...");
            ExibirContagemRegressiva(SegundosExpirando);
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}
