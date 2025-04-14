using System;
using System.Collections.Generic;

public class NoDialogo
{
    public string Texto { get; set; }
    public List<Opcao> Opcoes { get; set; } = new List<Opcao>();

    public NoDialogo(string texto)
    {
        Texto = texto;
    }

    public void Exibir()
    {
        Console.WriteLine($"\n{Texto}");

        if (Opcoes.Count == 0)
        {
            Console.WriteLine("(Fim do diálogo)");
            return;
        }

        for (int i = 0; i < Opcoes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Opcoes[i].TextoOpcao}");
        }

        Console.Write("\nEscolha uma opção: ");
        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= Opcoes.Count)
        {
            Opcoes[escolha - 1].ProximoNo?.Exibir();
        }
        else
        {
            Console.WriteLine("Opção inválida. Encerrando diálogo.");
        }
    }
}

public class Opcao
{
    public string TextoOpcao { get; set; }
    public NoDialogo ProximoNo { get; set; }

    public Opcao(string texto, NoDialogo proximo)
    {
        TextoOpcao = texto;
        ProximoNo = proximo;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Nós de diálogo
        NoDialogo inicio = new NoDialogo("Olá, viajante! O que deseja?");
        NoDialogo comprar = new NoDialogo("Claro! Temos poções e espadas. Deseja algo mais?");
        NoDialogo vender = new NoDialogo("O que você tem para vender?");
        NoDialogo sair = new NoDialogo("Boa viagem, herói!");

        // Conectando opções
        inicio.Opcoes.Add(new Opcao("Quero comprar.", comprar));
        inicio.Opcoes.Add(new Opcao("Quero vender.", vender));
        inicio.Opcoes.Add(new Opcao("Nada, obrigado.", sair));

        comprar.Opcoes.Add(new Opcao("Não, obrigado.", sair));
        vender.Opcoes.Add(new Opcao("Era só isso mesmo.", sair));

        // Iniciar diálogo
        inicio.Exibir();
    }
}