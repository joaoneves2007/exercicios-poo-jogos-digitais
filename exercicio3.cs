public class Arma : Item
{
    public Arma()
    {
        Nome = "Espada Mística";
    }

    public override void AplicarEfeito()
    {
        Console.WriteLine($"{Nome} equipada. Ataque aumentado!");
    }
}
public class Armadura : Item
{
    public Armadura()
    {
        Nome = "Armadura de Ferro";
    }

    public override void AplicarEfeito()
    {
        Console.WriteLine($"{Nome} equipada. Defesa aumentada!");
    }
}
public abstract class Item
{
    public string Nome { get; set; }
    public abstract void AplicarEfeito();
}
using System;

public class ItemFactory
{
    private static Random random = new Random();

    public static Item CriarItemAleatorio()
    {
        int tipo = random.Next(3);

        return tipo switch
        {
            0 => new Arma(),
            1 => new Pocao(),
            2 => new Armadura(),
            _ => throw new Exception("Tipo de item desconhecido")
        };
    }
}
public class Pocao : Item
{
    public Pocao()
    {
        Nome = "Poção de Vida";
    }

    public override void AplicarEfeito()
    {
        Console.WriteLine($"{Nome} usada. Vida recuperada!");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Item item = ItemFactory.CriarItemAleatorio();
            Console.WriteLine($"Item gerado: {item.Nome}");
            item.AplicarEfeito();
            Console.WriteLine();
        }
    }
}