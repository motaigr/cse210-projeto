using System;
using System.Collections.Generic;
using System.Threading;

// Classe base: guarda o estado e o fluxo comuns a todas as atividades.
// É abstrata porque uma "Atividade" genérica não executa sozinha;
// cada classe derivada fornece seu próprio Executar().
public abstract class Atividade
{
    private static readonly Random _aleatorio = new Random();

    private string _nome;
    private string _descricao;
    private int _duracao;

    protected Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    // Cada atividade derivada implementa seu próprio ciclo principal.
    public abstract void Executar();

    protected void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();

        _duracao = LerInteiroPositivo("Quanto tempo, em segundos, você gostaria que durasse a sessão? ");

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ExibirSpinner(3);
        Console.WriteLine();
    }

    protected void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!!");
        ExibirSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"Você completou mais {_duracao} segundos da {_nome}.");
        ExibirSpinner(3);
    }

    protected void ExibirSpinner(int segundos)
    {
        string[] quadros = { "|", "/", "-", "\\" };
        DateTime horaFinal = DateTime.Now.AddSeconds(segundos);
        int i = 0;

        while (DateTime.Now < horaFinal)
        {
            Console.Write(quadros[i % quadros.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            // Apaga todos os dígitos, para que "10" não deixe resto ao virar "9".
            string texto = i.ToString();
            Console.Write(texto);
            Thread.Sleep(1000);
            Console.Write(new string('\b', texto.Length) + new string(' ', texto.Length) + new string('\b', texto.Length));
        }
    }

    // Melhoria: retorna um item aleatório que não se repete até que todos os
    // itens da lista tenham sido usados uma vez. A lista "restantes" pertence
    // a quem chama, então o ciclo sem repetição continua entre várias execuções.
    protected string ObterAleatorioSemRepetir(List<string> todos, List<string> restantes)
    {
        if (restantes.Count == 0)
        {
            restantes.AddRange(todos);
        }

        int indice = _aleatorio.Next(restantes.Count);
        string item = restantes[indice];
        restantes.RemoveAt(indice);
        return item;
    }

    private static int LerInteiroPositivo(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
            {
                return valor;
            }
            Console.WriteLine("Digite um número inteiro maior que zero.");
        }
    }
}
