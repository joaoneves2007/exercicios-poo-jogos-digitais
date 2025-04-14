public class Arma
{
    public string Nome { get; set; }
    public int Dano { get; set; }

    public Arma(string nome, int dano)
    {
        Nome = nome;
        Dano = dano;
    }
}
public class Armadura
{
    public string Nome { get; set; }
    public int Defesa { get; set; }

    public Armadura(string nome, int defesa)
    {
        Nome = nome;
        Defesa = defesa;
    }
}
using System;

public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public Arma Arma { get; set; }
    public Armadura Armadura { get; set; }

    public Personagem(string nome, int vida)
    {
        Nome = nome;
        Vida = vida;
    }

    public void TrocarArma(Arma novaArma)
    {
        Arma = novaArma;
        Console.WriteLine($"{Nome} equipou a arma: {Arma.Nome} (Dano: {Arma.Dano})");
    }

    public void TrocarArmadura(Armadura novaArmadura)
    {
        Armadura = novaArmadura;
        Console.WriteLine($"{Nome} equipou a armadura: {Armadura.Nome} (Defesa: {Armadura.Defesa})");
    }

    public void MostrarStatus()
    {
        Console.WriteLine($"\n{Nome} - Vida: {Vida}");
        Console.WriteLine($"Arma: {(Arma != null ? Arma.Nome : "Nenhuma")} | Dano: {(Arma != null ? Arma.Dano.ToString() : "0")}");
        Console.WriteLine($"Armadura: {(Armadura != null ? Armadura.Nome : "Nenhuma")} | Defesa: {(Armadura != null ? Armadura.Defesa.ToString() : "0")}\n");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Personagem jogador = new Personagem("Luna", 100);

        Arma espada = new Arma("Espada Longa", 25);
        Armadura armaduraCouro = new Armadura("Armadura de Couro", 10);

        jogador.TrocarArma(espada);
        jogador.TrocarArmadura(armaduraCouro);
        jogador.MostrarStatus();

        Arma arco = new Arma("Arco Rápido", 18);
        Armadura armaduraFerro = new Armadura("Armadura de Ferro", 20);

        jogador.TrocarArma(arco);
        jogador.TrocarArmadura(armaduraFerro);
        jogador.MostrarStatus();
    }
}
