public abstract class Habilidade
{
    public string Nome { get; set; }
    public int CustoDeMana { get; set; }
    public int Dano { get; set; }

    public abstract void Usar();
}
public class BolaDeFogo : Habilidade
{
    public BolaDeFogo()
    {
        Nome = "Bola de Fogo";
        CustoDeMana = 10;
        Dano = 30;
    }

    public override void Usar()
    {
        Console.WriteLine($"{Nome} lançada! Dano: {Dano}. Mana usada: {CustoDeMana}.");
    }
}
public class RaioDeGelo : Habilidade
{
    public RaioDeGelo()
    {
        Nome = "Raio de Gelo";
        CustoDeMana = 12;
        Dano = 25;
    }

    public override void Usar()
    {
        Console.WriteLine($"{Nome} lançado! Dano: {Dano}. Mana usada: {CustoDeMana}.");
    }
}
public class GolpeDeEspada : Habilidade
{
    public GolpeDeEspada()
    {
        Nome = "Golpe de Espada";
        CustoDeMana = 0;
        Dano = 20;
    }

    public override void Usar()
    {
        Console.WriteLine($"{Nome} executado! Dano: {Dano}.");
    }
}
using System;
using System.Collections.Generic;

public class Personagem
{
    public string Nome { get; set; }
    public int Mana { get; set; }
    public List<Habilidade> Habilidades { get; private set; } = new List<Habilidade>();

    public Personagem(string nome, int mana)
    {
        Nome = nome;
        Mana = mana;
    }

    public void AdicionarHabilidade(Habilidade habilidade)
    {
        Habilidades.Add(habilidade);
        Console.WriteLine($"Habilidade {habilidade.Nome} adicionada a {Nome}.");
    }

    public void UsarHabilidade(string nomeHabilidade)
    {
        var habilidade = Habilidades.Find(h => h.Nome == nomeHabilidade);
        if (habilidade != null)
        {
            if (Mana >= habilidade.CustoDeMana)
            {
                habilidade.Usar();
                Mana -= habilidade.CustoDeMana;
                Console.WriteLine($"Mana restante de {Nome}: {Mana}");
            }
            else
            {
                Console.WriteLine($"Mana insuficiente para usar {habilidade.Nome}.");
            }
        }
        else
        {
            Console.WriteLine($"Habilidade {nomeHabilidade} não encontrada.");
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Personagem heroi = new Personagem("Arthas", 30);

        heroi.AdicionarHabilidade(new BolaDeFogo());
        heroi.AdicionarHabilidade(new RaioDeGelo());
        heroi.AdicionarHabilidade(new GolpeDeEspada());

        heroi.UsarHabilidade("Bola de Fogo");
        heroi.UsarHabilidade("Raio de Gelo");
        heroi.UsarHabilidade("Golpe de Espada");
    }
}
