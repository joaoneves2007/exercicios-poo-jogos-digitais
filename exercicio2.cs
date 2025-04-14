public class Arqueiro : IAtacante
{
    public void Atacar(Inimigo inimigo)
    {
        Console.WriteLine("Arqueiro dispara uma flecha!");
        inimigo.ReceberDano(15);
    }
}
public class Guerreiro : IAtacante
{
    public void Atacar(Inimigo inimigo)
    {
        Console.WriteLine("Guerreiro ataca com espada!");
        inimigo.ReceberDano(20);
    }
}
public interface IAtacante
{
    void Atacar(Inimigo inimigo);
}
public class Inimigo
{
    public int Vida { get; private set; } = 100;

    public void ReceberDano(int dano)
    {
        Vida -= dano;
        Console.WriteLine($"Inimigo recebeu {dano} de dano. Vida restante: {Vida}");
    }
}
public class Mago : IAtacante
{
    public void Atacar(Inimigo inimigo)
    {
        Console.WriteLine("Mago lança uma bola de fogo!");
        inimigo.ReceberDano(25);
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Inimigo inimigo = new Inimigo();

        IAtacante guerreiro = new Guerreiro();
        IAtacante mago = new Mago();
        IAtacante arqueiro = new Arqueiro();

        guerreiro.Atacar(inimigo);
        mago.Atacar(inimigo);
        arqueiro.Atacar(inimigo);
    }
}
