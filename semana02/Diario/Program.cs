// =========================================================================================
// CRIATIVIDADE E REQUISITOS ADICIONAIS:
// 1. Foi adicionada uma pergunta extra à lista padrão no PromptGenerator.
// 2. Utilizado um delimitador personalizado ("|~|") para garantir que vírgulas ou pontuações
//    comuns no texto escrito pelo usuário não quebrem a leitura do arquivo ao carregar.
// =========================================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu do Diário:");
            Console.WriteLine("1. Escrever um novo registro");
            Console.WriteLine("2. Exibir o diário");
            Console.WriteLine("3. Carregar o diário de um arquivo");
            Console.WriteLine("4. Salvar o diário em um arquivo");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPergunta: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    Console.WriteLine("\n--- Registros do Diário ---");
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Digite o nome do arquivo para carregar: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Digite o nome do arquivo para salvar: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}