using System;
using System.Collections.Generic;

// SUPERANDO OS REQUISITOS
// 1. Sem repetição: as atividades de Reflexão e Listagem não repetem uma sugestão
//    ou pergunta até que todos os itens da lista tenham sido usados uma vez
//    (Atividade.ObterAleatorioSemRepetir). Como cada atividade é criada uma única
//    vez e reutilizada, isso vale para várias execuções na mesma sessão.
// 2. Registro da sessão: o programa conta quantas vezes cada atividade foi
//    concluída e o total de segundos praticados, e mostra um resumo ao sair.
// 3. Validação de entrada: a duração só aceita números inteiros positivos e
//    opções inválidas do menu são tratadas sem erro.

class Program
{
    static void Main(string[] args)
    {
        // Criadas uma única vez para que o controle de repetição persista entre execuções.
        Dictionary<string, Atividade> atividades = new Dictionary<string, Atividade>
        {
            { "1", new AtividadeDeRespiracao() },
            { "2", new AtividadeDeReflexao() },
            { "3", new AtividadeDeListagem() }
        };

        Dictionary<string, int> vezesConcluidas = new Dictionary<string, int>();
        int totalSegundos = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Opções do menu:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Sair");
            Console.Write("Selecione uma opção do menu: ");

            string escolha = Console.ReadLine()?.Trim();

            if (escolha == "4")
            {
                break;
            }

            if (atividades.TryGetValue(escolha ?? "", out Atividade atividade))
            {
                // Polimorfismo: o Executar() correto é chamado para cada classe derivada.
                atividade.Executar();

                string nome = atividade.ObterNome();
                vezesConcluidas[nome] = vezesConcluidas.GetValueOrDefault(nome) + 1;
                totalSegundos += atividade.ObterDuracao();
            }
            else
            {
                Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente.");
                Console.ReadLine();
            }
        }

        ExibirResumoDaSessao(vezesConcluidas, totalSegundos);
    }

    static void ExibirResumoDaSessao(Dictionary<string, int> vezesConcluidas, int totalSegundos)
    {
        Console.Clear();
        Console.WriteLine("Resumo da sessão:");

        if (vezesConcluidas.Count == 0)
        {
            Console.WriteLine("  Nenhuma atividade concluída desta vez.");
        }
        else
        {
            foreach (KeyValuePair<string, int> registro in vezesConcluidas)
            {
                Console.WriteLine($"  {registro.Key}: {registro.Value} vez(es)");
            }
            Console.WriteLine($"  Tempo total de atenção plena: {totalSegundos} segundos");
        }

        Console.WriteLine("Até logo!");
    }
}
