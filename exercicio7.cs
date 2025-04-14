public abstract class Missao
{
    public string Nome { get; set; }
    public bool Concluida { get; protected set; }

    public Missao(string nome)
    {
        Nome = nome;
        Concluida = false;
    }

    public abstract void Executar();
}
public class MissaoDerrotarInimigos : Missao
{
    public int InimigosRestantes { get; set; }

    public MissaoDerrotarInimigos() : base("Derrotar Inimigos")
    {
        InimigosRestantes = 3;
    }

    public override void Executar()
    {
        InimigosRestantes--;
        Console.WriteLine($"Inimigos restantes: {InimigosRestantes}");

        if (InimigosRestantes <= 0)
        {
            Concluida = true;
            Console.WriteLine($"Missão '{Nome}' concluída!");
        }
    }
}
public class MissaoColetarItens : Missao
{
    public int ItensNecessarios { get; set; }

    public MissaoColetarItens() : base("Coletar Itens")
    {
        ItensNecessarios = 5;
    }

    public override void Executar()
    {
        ItensNecessarios--;
        Console.WriteLine($"Itens restantes para coletar: {ItensNecessarios}");

        if (ItensNecessarios <= 0)
        {
            Concluida = true;
            Console.WriteLine($"Missão '{Nome}' concluída!");
        }
    }
}
public class MissaoExplorarArea : Missao
{
    public bool AreaExplorada { get; private set; }

    public MissaoExplorarArea() : base("Explorar Área") { }

    public override void Executar()
    {
        AreaExplorada = true;
        Concluida = true;
        Console.WriteLine($"Missão '{Nome}' concluída! Área explorada com sucesso.");
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Missao> missoes = new List<Missao>
        {
            new MissaoDerrotarInimigos(),
            new MissaoColetarItens(),
            new MissaoExplorarArea()
        };

        foreach (var missao in missoes)
        {
            Console.WriteLine($"> Iniciando missão: {missao.Nome}");

            while (!missao.Concluida)
            {
                missao.Executar();
            }

            Console.WriteLine();
        }
    }
}
