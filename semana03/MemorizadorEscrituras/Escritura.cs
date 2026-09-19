using System;
using System.Collections.Generic;
using System.Linq;

public class Escritura
{
    private readonly Referencia _referencia;
    private readonly List<Palavra> _palavras;
    private static readonly Random _sorteador = new Random();

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = texto
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(palavraTexto => new Palavra(palavraTexto))
            .ToList();
    }

    public void EsconderPalavrasAleatorias(int numeroParaEsconder)
    {
        List<Palavra> palavrasVisiveis = _palavras
            .Where(palavra => !palavra.EstaEscondida())
            .ToList();

        for (int i = 0; i < numeroParaEsconder && palavrasVisiveis.Count > 0; i++)
        {
            int indiceSorteado = _sorteador.Next(palavrasVisiveis.Count);
            palavrasVisiveis[indiceSorteado].Esconder();
            palavrasVisiveis.RemoveAt(indiceSorteado);
        }
    }

    public string ObterTextoExibicao()
    {
        string textoPalavras = string.Join(" ", _palavras.Select(palavra => palavra.ObterTextoExibicao()));
        return $"{_referencia.ObterTextoExibicao()}\n\n{textoPalavras}";
    }

    public bool EstaCompletamenteEscondida()
    {
        return _palavras.All(palavra => palavra.EstaEscondida());
    }

    public int ObterQuantidadeDePalavras()
    {
        return _palavras.Count;
    }

    public int ObterQuantidadeDePalavrasEscondidas()
    {
        return _palavras.Count(palavra => palavra.EstaEscondida());
    }
}
