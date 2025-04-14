public abstract class Carta
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public int Dano { get; set; }

    public Carta(string nome, int vida, int dano)
    {
        Nome = nome;
        Vida = vida;
        Dano = dano;
    }

    public abstract void UsarHabilidade(Carta alvo);

    public bool EstaViva => Vida > 0;

    public void MostrarStatus()
    {
        Console.WriteLine($"{Nome} | Vida: {Vida} | Dano: {Dano}");
    }
}
using System;

public class Guerreiro : Carta
{
    public Guerreiro() : base("Guerreiro", 100, 20) { }

    public override void UsarHabilidade(Carta alvo)
    {
        Console.WriteLine($"{Nome} usa Golpe de Espada em {alvo.Nome}");
        alvo.Vida -= Dano;
    }
}
using System;

public class Mago : Carta
{
    public Mago() : base("Mago", 80, 25) { }

    public override void UsarHabilidade(Carta alvo)
    {
        Console.WriteLine($"{Nome} lança Bola de Fogo em {alvo.Nome}");
        alvo.Vida -= Dano;
    }
}
using System;

public class Assassino : Carta
{
    public Assassino() : base("Assassino", 70, 30) { }

    public override void UsarHabilidade(Carta alvo)
    {
        Console.WriteLine($"{Nome} ataca silenciosamente {alvo.Nome}");
        alvo.Vida -= Dano;
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Carta jogador1 = new Guerreiro();
        Carta jogador2 = new Mago();

        Console.WriteLine("=== Batalha de Cartas ===");
        jogador1.MostrarStatus();
        jogador2.MostrarStatus();
        Console.WriteLine();

        int turno = 1;

        while (jogador1.EstaViva && jogador2.EstaViva)
        {
            Console.WriteLine($"\n--- Turno {turno} ---");

            jogador1.UsarHabilidade(jogador2);
            if (!jogador2.EstaViva) break;

            jogador2.UsarHabilidade(jogador1);
            turno++;

            jogador1.MostrarStatus();
            jogador2.MostrarStatus();
        }

        Console.WriteLine("\n=== Fim da Batalha ===");
        Console.WriteLine(jogador1.EstaViva ? $"{jogador1.Nome} venceu!" : $"{jogador2.Nome} venceu!");
    }
}
