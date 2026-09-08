using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Criar o primeiro emprego
        Emprego emprego1 = new Emprego();
        emprego1._cargo = "Engenheiro de Software";
        emprego1._empresa = "Microsoft";
        emprego1._anoInicio = 2019;
        emprego1._anoFim = 2022;

        // 2. Criar o segundo emprego
        Emprego emprego2 = new Emprego();
        emprego2._cargo = "Desenvolvedor C#";
        emprego2._empresa = "Apple";
        emprego2._anoInicio = 2022;
        emprego2._anoFim = 2024;

        // 3. Criar o currículo
        Curriculo meuCurriculo = new Curriculo();
        meuCurriculo._nome = "Antonio Carlos";

        // 4. Adicionar os empregos à lista do currículo
        meuCurriculo._empregos.Add(emprego1);
        meuCurriculo._empregos.Add(emprego2);

        // 5. Exibir as informações na tela
        meuCurriculo.Exibir();
    }
}