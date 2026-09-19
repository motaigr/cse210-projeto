using System;
using System.Collections.Generic;

// ==========================================================================
// Indo além dos requisitos básicos:
//
// 1. Biblioteca de escrituras: em vez de trabalhar com uma única escritura
//    fixa, o programa mantém uma pequena biblioteca de escrituras e sorteia
//    uma aleatoriamente a cada execução, para que a prática não fique
//    repetitiva.
// 2. Seleção inteligente de palavras: Escritura.EsconderPalavrasAleatorias
//    escolhe apenas entre as palavras que ainda estão visíveis, evitando
//    "desperdiçar" uma rodada sorteando uma palavra que já está escondida.
// 3. Ocultação progressiva: o número de palavras escondidas por rodada
//    aumenta a cada rodada (começando devagar, para dar tempo de decorar as
//    primeiras palavras, e acelerando depois), evitando que escrituras
//    longas levem um número excessivo de rodadas para ficarem 100%
//    escondidas.
// 4. Indicador de progresso: a cada rodada o programa mostra quantas
//    palavras já foram escondidas em relação ao total, ajudando o usuário a
//    perceber o quanto falta para memorizar o texto por completo.
// ==========================================================================

class Program
{
    static void Main(string[] args)
    {
        List<Escritura> biblioteca = CriarBibliotecaDeEscrituras();
        Random sorteador = new Random();
        Escritura escritura = biblioteca[sorteador.Next(biblioteca.Count)];

        int rodada = 1;
        while (!escritura.EstaCompletamenteEscondida())
        {
            LimparConsole();
            Console.WriteLine(escritura.ObterTextoExibicao());
            Console.WriteLine();
            Console.WriteLine($"Palavras escondidas: {escritura.ObterQuantidadeDePalavrasEscondidas()}/{escritura.ObterQuantidadeDePalavras()}");
            Console.WriteLine("Pressione Enter para continuar ou digite 'sair' para encerrar.");

            string entrada = Console.ReadLine();
            if (entrada != null && entrada.Trim().Equals("sair", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            escritura.EsconderPalavrasAleatorias(rodada);
            rodada++;
        }

        LimparConsole();
        Console.WriteLine(escritura.ObterTextoExibicao());
        Console.WriteLine();
        Console.WriteLine("Parabéns! Você escondeu a escritura inteira.");
    }

    private static void LimparConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
        }
    }

    private static List<Escritura> CriarBibliotecaDeEscrituras()
    {
        return new List<Escritura>
        {
            new Escritura(
                new Referencia("João", 3, 16),
                "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito, para que todo aquele que nele crê não pereça, mas tenha a vida eterna."),

            new Escritura(
                new Referencia("Provérbios", 3, 5, 6),
                "Confie no Senhor de todo o seu coração e não se apoie em seu próprio entendimento; reconheça o Senhor em todos os seus caminhos e ele endireitará as suas veredas."),

            new Escritura(
                new Referencia("Filipenses", 4, 13),
                "Tudo posso naquele que me fortalece."),

            new Escritura(
                new Referencia("Josué", 1, 9),
                "Não fui eu que ordenei a você? Seja forte e corajoso! Não se apavore, nem se desanime, pois o Senhor, o seu Deus, estará com você por onde você andar.")
        };
    }
}
