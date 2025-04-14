public class Guarda : NPC
{
    public Guarda(string nome) : base(nome) {}

    public override void Mover()
    {
        Console.WriteLine($"{Nome} está patrulhando a área.");
    }

    public override void Interagir()
    {
        Console.WriteLine($"{Nome} diz: Tudo tranquilo por aqui.");
    }
}
public abstract class NPC
{
    public string Nome { get; set; }

    public NPC(string nome)
    {
        Nome = nome;
    }

    public abstract void Mover();
    public abstract void Interagir();
}
using System;

class Program
{
    static void Main(string[] args)
    {
        NPC vendedor = new Vendedor("Carlos");
        NPC guarda = new Guarda("Roberto");
        NPC vilao = new Vilao("Sombrio");

        vendedor.Mover();
        vendedor.Interagir();

        guarda.Mover();
        guarda.Interagir();

        vilao.Mover();
        vilao.Interagir();
    }
}
public class Vendedor : NPC
{
    public Vendedor(string nome) : base(nome) {}

    public override void Mover()
    {
        Console.WriteLine($"{Nome} está andando pela loja.");
    }

    public override void Interagir()
    {
        Console.WriteLine($"{Nome} diz: Olá, quer comprar algo?");
    }
}
public class Vilao : NPC
{
    public Vilao(string nome) : base(nome) {}

    public override void Mover()
    {
        Console.WriteLine($"{Nome} está perseguindo o jogador!");
    }

    public override void Interagir()
    {
        Console.WriteLine($"{Nome} ataca o jogador!");
    }
}