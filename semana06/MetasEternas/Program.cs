// Programa de Metas Eternas (Eternal Quest) - CSE 210, Semana 06
//
// FUNCIONALIDADES EXTRAS (criatividade):
//
// 1. Sistema de Níveis: a cada 1000 pontos o jogador sobe um nível, e cada
//    nível tem um título (1 - Novato, 2 - Aventureiro, 3 - Explorador,
//    4 - Guerreiro, 5 - Campeão, 6 - Herói, 7+ - Lenda). O nível, o título e
//    quantos pontos faltam para o próximo nível aparecem junto com a pontuação.
//
// 2. Mensagens comemorativas: ao concluir uma meta (simples ou checklist) ou
//    ao subir de nível, o programa exibe uma faixa destacada em amarelo.
//
// 3. Robustez: as entradas numéricas são validadas (não quebra com texto
//    inválido), metas já concluídas não pontuam de novo, e um arquivo
//    corrompido não apaga o progresso atual ao ser carregado.

class Program
{
    static void Main(string[] args)
    {
        GerenciadorMetas gerenciador = new GerenciadorMetas();
        gerenciador.Iniciar();
    }
}
