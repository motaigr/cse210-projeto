using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Classe base
        Tarefa tarefa = new Tarefa("Samuel Silva", "Multiplicação");
        Console.WriteLine(tarefa.ObterResumo());
        Console.WriteLine();

        // 2. Tarefa de Matemática
        TarefaDeMatematica tarefaMatematica = new TarefaDeMatematica("Roberto Rodrigues", "Frações", "7.3", "8-19");
        Console.WriteLine(tarefaMatematica.ObterResumo());
        Console.WriteLine(tarefaMatematica.ObterListaDeTarefas());
        Console.WriteLine();

        // 3. Tarefa de Redação
        TarefaDeRedacao tarefaRedacao = new TarefaDeRedacao("Maria Antunes", "História Europeia", "As Causas da Segunda Guerra Mundial");
        Console.WriteLine(tarefaRedacao.ObterResumo());
        Console.WriteLine(tarefaRedacao.ObterInformacoesDaRedacao());
    }
}
