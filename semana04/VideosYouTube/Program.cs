using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Como aprender C# do zero", "Código Fácil", 754);
        video1.AdicionarComentario(new Comentario("Ana", "Ótimo vídeo!"));
        video1.AdicionarComentario(new Comentario("Bruno", "Me ajudou muito, obrigado!"));
        video1.AdicionarComentario(new Comentario("Carla", "Explicação bem clara."));
        video1.AdicionarComentario(new Comentario("Diego", "Poderia fazer um sobre POO também."));

        Video video2 = new Video("Receita de bolo de chocolate", "Cozinha da Vovó", 480);
        video2.AdicionarComentario(new Comentario("Elisa", "Fiz e ficou uma delícia!"));
        video2.AdicionarComentario(new Comentario("Fábio", "Minha família amou."));
        video2.AdicionarComentario(new Comentario("Gustavo", "Qual marca de chocolate você usa?"));

        Video video3 = new Video("Melhores destinos para viajar em 2026", "Mundo Afora", 620);
        video3.AdicionarComentario(new Comentario("Helena", "Já visitei dois desses lugares!"));
        video3.AdicionarComentario(new Comentario("Igor", "Vídeo muito inspirador."));
        video3.AdicionarComentario(new Comentario("Julia", "Adicionei tudo à minha lista de desejos."));
        video3.AdicionarComentario(new Comentario("Kleber", "Faltou falar sobre o custo de vida."));

        Video video4 = new Video("Treino de 20 minutos em casa", "Fit em Casa", 1200);
        video4.AdicionarComentario(new Comentario("Larissa", "Suei muito, adorei!"));
        video4.AdicionarComentario(new Comentario("Marcos", "Ótimo para quem não tem tempo."));
        video4.AdicionarComentario(new Comentario("Nina", "Pode fazer um nível avançado?"));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };

        foreach (Video video in videos)
        {
            video.ExibirDetalhes();
            Console.WriteLine("----------------------------------------");
        }
    }
}
