using System;
using System.Collections.Generic;
using System.IO;

// Controla a lista de metas, a pontuação, os menus e o salvamento/carregamento.
public class GerenciadorMetas
{
    private const int PontosPorNivel = 1000;

    private static readonly string[] _titulosNiveis =
    {
        "Novato", "Aventureiro", "Explorador", "Guerreiro", "Campeão", "Herói", "Lenda"
    };

    private List<Meta> _metas = new List<Meta>();
    private int _pontuacao = 0;

    public void Iniciar()
    {
        string opcao = "";

        while (opcao != "7")
        {
            Console.WriteLine();
            ExibirInfoJogador();
            Console.WriteLine();
            Console.WriteLine("Opções do menu:");
            Console.WriteLine("  1. Criar nova meta");
            Console.WriteLine("  2. Listar metas");
            Console.WriteLine("  3. Salvar metas");
            Console.WriteLine("  4. Carregar metas");
            Console.WriteLine("  5. Registrar evento");
            Console.WriteLine("  6. Exibir informações do jogador");
            Console.WriteLine("  7. Sair");
            Console.Write("Selecione uma opção: ");
            opcao = Console.ReadLine()?.Trim() ?? "7";

            switch (opcao)
            {
                case "1": CriarMeta(); break;
                case "2": ListarDetalhesMetas(); break;
                case "3": SalvarMetas(); break;
                case "4": CarregarMetas(); break;
                case "5": RegistrarEvento(); break;
                case "6": ExibirInfoJogador(); break;
                case "7": Console.WriteLine("Até a próxima jornada!"); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
    }

    public void ExibirInfoJogador()
    {
        int nivel = CalcularNivel(_pontuacao);
        int faltam = nivel * PontosPorNivel - _pontuacao;

        Console.WriteLine($"Você tem {_pontuacao} pontos.");
        Console.WriteLine($"Nível {nivel} - {ObterTituloNivel(nivel)} ({faltam} pontos para o próximo nível)");
    }

    public void ListarDetalhesMetas()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        Console.WriteLine("Suas metas:");
        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_metas[i].ObterDetalhes()}");
        }
    }

    public void CriarMeta()
    {
        Console.WriteLine("Tipos de meta:");
        Console.WriteLine("  1. Meta simples");
        Console.WriteLine("  2. Meta eterna");
        Console.WriteLine("  3. Meta checklist");
        int tipo = LerInteiro("Qual tipo de meta você deseja criar? ", 1, 3);

        string nome = LerTexto("Qual é o nome da sua meta? ");
        string descricao = LerTexto("Qual é uma breve descrição dela? ");
        int pontos = LerInteiro("Quantos pontos ela vale? ", 1);

        Meta meta;
        switch (tipo)
        {
            case 1:
                meta = new MetaSimples(nome, descricao, pontos);
                break;
            case 2:
                meta = new MetaEterna(nome, descricao, pontos);
                break;
            default:
                int vezes = LerInteiro("Quantas vezes ela precisa ser realizada para ser concluída? ", 1);
                int bonus = LerInteiro("Qual é o bônus por concluí-la? ", 0);
                meta = new MetaChecklist(nome, descricao, pontos, vezes, bonus);
                break;
        }

        _metas.Add(meta);
        Console.WriteLine("Meta criada com sucesso!");
    }

    public void RegistrarEvento()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        Console.WriteLine("As metas são:");
        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_metas[i].ObterNome()}");
        }
        int indice = LerInteiro("Qual meta você realizou? ", 1, _metas.Count) - 1;
        Meta meta = _metas[indice];

        if (meta.EstaCompleta())
        {
            Console.WriteLine("Essa meta já foi concluída. Escolha outra ou crie uma nova!");
            return;
        }

        int nivelAnterior = CalcularNivel(_pontuacao);
        int ganhos = meta.RegistrarEvento();
        _pontuacao += ganhos;

        Console.WriteLine($"Parabéns! Você ganhou {ganhos} pontos!");

        if (meta.EstaCompleta())
        {
            Comemorar($"META CONCLUÍDA: {meta.ObterNome()}!");
        }

        int nivelAtual = CalcularNivel(_pontuacao);
        if (nivelAtual > nivelAnterior)
        {
            Comemorar($"SUBIU DE NÍVEL! Agora você é Nível {nivelAtual} - {ObterTituloNivel(nivelAtual)}!");
        }

        Console.WriteLine($"Agora você tem {_pontuacao} pontos.");
    }

    public void SalvarMetas()
    {
        string arquivo = LerTexto("Qual é o nome do arquivo? ");

        using (StreamWriter saida = new StreamWriter(arquivo))
        {
            saida.WriteLine(_pontuacao);
            foreach (Meta meta in _metas)
            {
                saida.WriteLine(meta.ObterRepresentacaoTexto());
            }
        }

        Console.WriteLine($"Metas salvas em \"{arquivo}\".");
    }

    public void CarregarMetas()
    {
        string arquivo = LerTexto("Qual é o nome do arquivo? ");

        if (!File.Exists(arquivo))
        {
            Console.WriteLine($"Arquivo \"{arquivo}\" não encontrado.");
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(arquivo);
            List<Meta> metas = new List<Meta>();

            for (int i = 1; i < linhas.Length; i++)
            {
                if (linhas[i].Trim() != "")
                {
                    metas.Add(CriarMetaDeTexto(linhas[i]));
                }
            }

            // Só substitui o estado atual se o arquivo inteiro foi lido sem erros.
            _pontuacao = int.Parse(linhas[0]);
            _metas = metas;
            Console.WriteLine($"{_metas.Count} meta(s) carregada(s) de \"{arquivo}\".");
        }
        catch (Exception erro) when (erro is FormatException || erro is IndexOutOfRangeException)
        {
            Console.WriteLine($"Arquivo inválido: {erro.Message}");
        }
    }

    // Fábrica: reconstrói o objeto correto a partir de uma linha do arquivo.
    private Meta CriarMetaDeTexto(string linha)
    {
        int doisPontos = linha.IndexOf(':');
        if (doisPontos < 0)
        {
            throw new FormatException($"linha sem tipo de meta: \"{linha}\"");
        }

        string tipo = linha.Substring(0, doisPontos);
        string[] partes = linha.Substring(doisPontos + 1).Split(Meta.Separador);

        string nome = partes[0];
        string descricao = partes[1];
        int pontos = int.Parse(partes[2]);

        switch (tipo)
        {
            case "MetaSimples":
                return new MetaSimples(nome, descricao, pontos, bool.Parse(partes[3]));
            case "MetaEterna":
                return new MetaEterna(nome, descricao, pontos);
            case "MetaChecklist":
                int bonus = int.Parse(partes[3]);
                int vezesAlvo = int.Parse(partes[4]);
                int vezesRealizadas = int.Parse(partes[5]);
                return new MetaChecklist(nome, descricao, pontos, vezesAlvo, bonus, vezesRealizadas);
            default:
                throw new FormatException($"tipo de meta desconhecido: \"{tipo}\"");
        }
    }

    private static int CalcularNivel(int pontos)
    {
        return pontos / PontosPorNivel + 1;
    }

    private static string ObterTituloNivel(int nivel)
    {
        // Depois do último título, o jogador continua "Lenda".
        int indice = Math.Min(nivel, _titulosNiveis.Length) - 1;
        return _titulosNiveis[indice];
    }

    private static void Comemorar(string mensagem)
    {
        string borda = new string('*', mensagem.Length + 8);
        ConsoleColor corOriginal = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine(borda);
        Console.WriteLine($"*** {mensagem} ***");
        Console.WriteLine(borda);
        Console.ForegroundColor = corOriginal;
    }

    private static string LerTexto(string pergunta)
    {
        while (true)
        {
            Console.Write(pergunta);
            // Remove o separador para não corromper o arquivo de salvamento.
            string texto = (Console.ReadLine() ?? "").Replace(Meta.Separador.ToString(), "").Trim();
            if (texto != "")
            {
                return texto;
            }
            Console.WriteLine("O valor não pode ficar vazio.");
        }
    }

    private static int LerInteiro(string pergunta, int minimo, int maximo = int.MaxValue)
    {
        while (true)
        {
            Console.Write(pergunta);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= minimo && valor <= maximo)
            {
                return valor;
            }
            Console.WriteLine("Digite um número válido.");
        }
    }
}
