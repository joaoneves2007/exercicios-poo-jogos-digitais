public class Item
{
    public string Nome { get; set; }
    public string Tipo { get; set; } // Vida, Dano, Velocidade

    public Item(string nome, string tipo)
    {
        Nome = nome;
        Tipo = tipo;
    }

    public void Usar()
    {
        Console.WriteLine($"{Nome} usado. Efeito: {Tipo}");
    }
}
using System;
using System.Collections.Generic;

public class Inventario
{
    private List<Item> itens = new List<Item>();
    public int CapacidadeMaxima { get; private set; }

    public Inventario(int capacidade)
    {
        CapacidadeMaxima = capacidade;
    }

    public void AdicionarItem(Item item)
    {
        if (itens.Count >= CapacidadeMaxima)
        {
            Console.WriteLine("Inventário cheio! Não é possível adicionar mais itens.");
            return;
        }
        itens.Add(item);
        Console.WriteLine($"Item {item.Nome} adicionado ao inventário.");
    }

    public void RemoverItem(string nome)
    {
        var item = itens.Find(i => i.Nome == nome);
        if (item != null)
        {
            itens.Remove(item);
            Console.WriteLine($"Item {nome} removido do inventário.");
        }
        else
        {
            Console.WriteLine($"Item {nome} não encontrado.");
        }
    }

    public void UsarItem(string nome)
    {
        var item = itens.Find(i => i.Nome == nome);
        if (item != null)
        {
            item.Usar();
            itens.Remove(item);
        }
        else
        {
            Console.WriteLine($"Item {nome} não encontrado.");
        }
    }

    public void ListarItens()
    {
        Console.WriteLine("Itens no inventário:");
        foreach (var item in itens)
        {
            Console.WriteLine($"- {item.Nome} ({item.Tipo})");
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario(5);

        Item pocaoVida = new Item("Poção de Vida", "Recuperar Vida");
        Item botaRapida = new Item("Bota Veloz", "Aumentar Velocidade");
        Item espada = new Item("Espada Flamejante", "Aumentar Dano");

        inventario.AdicionarItem(pocaoVida);
        inventario.AdicionarItem(botaRapida);
        inventario.AdicionarItem(espada);

        inventario.ListarItens();

        inventario.UsarItem("Poção de Vida");
        inventario.RemoverItem("Espada Flamejante");

        inventario.ListarItens();
    }
}
