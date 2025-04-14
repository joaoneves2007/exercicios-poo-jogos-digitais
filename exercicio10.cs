public interface IObservador
{
    void Atualizar(string item, float novoPreco);
}
using System;

public class Comerciante : IObservador
{
    public string Nome { get; set; }

    public Comerciante(string nome)
    {
        Nome = nome;
    }

    public void Atualizar(string item, float novoPreco)
    {
        Console.WriteLine($"[{Nome}] Preço do item '{item}' atualizado para {novoPreco:C2}");
    }
}
using System;
using System.Collections.Generic;

public class Economia
{
    private Dictionary<string, float> precos = new Dictionary<string, float>();
    private List<IObservador> observadores = new List<IObservador>();

    public void RegistrarObservador(IObservador observador)
    {
        observadores.Add(observador);
    }

    public void AlterarPreco(string item, float novoPreco)
    {
        precos[item] = novoPreco;
        Notificar(item, novoPreco);
    }

    private void Notificar(string item, float novoPreco)
    {
        foreach (var obs in observadores)
        {
            obs.Atualizar(item, novoPreco);
        }
    }

    public float ObterPreco(string item)
    {
        return precos.ContainsKey(item) ? precos[item] : 0;
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Economia economia = new Economia();

        Comerciante comerciante1 = new Comerciante("Marcus");
        Comerciante comerciante2 = new Comerciante("Lucia");

        economia.RegistrarObservador(comerciante1);
        economia.RegistrarObservador(comerciante2);

        economia.AlterarPreco("Espada", 50f);
        economia.AlterarPreco("Espada", 30f);
        economia.AlterarPreco("Poção", 10f);
    }
}
