using System;

public class Personagem
{
    public string Nome { get; set; }
    public int Nivel { get; private set; }
    public int Experiencia { get; private set; }
    public int Forca { get; private set; }
    public int Agilidade { get; private set; }
    public int Vida { get; private set; }

    public Personagem(string nome)
    {
        Nome = nome;
        Nivel = 1;
        Experiencia = 0;
        Forca = 10;
        Agilidade = 10;
        Vida = 100;
    }

    public void GanharExperiencia(int quantidade)
    {
        Experiencia += quantidade;
        Console.WriteLine($"{Nome} ganhou {quantidade} de experiência.");

        while (Experiencia >= Nivel * 100)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        Experiencia -= Nivel * 100;
        Nivel++;
        Forca += 5;
        Agilidade += 5;
        Vida += 20;

        Console.WriteLine($"{Nome} subiu para o nível {Nivel}!");
        Console.WriteLine($"Atributos: Força {Forca}, Agilidade {Agilidade}, Vida {Vida}");
    }

    public void MostrarStatus()
    {
        Console.WriteLine($"\n{Nome} - Nível: {Nivel}, EXP: {Experiencia}");
        Console.WriteLine($"Força: {Forca}, Agilidade: {Agilidade}, Vida: {Vida}\n");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Personagem heroi = new Personagem("Dario");

        heroi.MostrarStatus();

        heroi.GanharExperiencia(120);
        heroi.GanharExperiencia(100);
        heroi.GanharExperiencia(180);

        heroi.MostrarStatus();
    }
}
