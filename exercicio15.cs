public interface IEstado
{
    void Executar(Inimigo inimigo);
}
using System;

public class EstadoPatrulha : IEstado
{
    public void Executar(Inimigo inimigo)
    {
        Console.WriteLine("Inimigo está patrulhando...");
        inimigo.MudarEstado(new EstadoPerseguir());
    }
}
using System;

public class EstadoPerseguir : IEstado
{
    public void Executar(Inimigo inimigo)
    {
        Console.WriteLine("Inimigo está perseguindo o jogador...");
        inimigo.MudarEstado(new EstadoAtacar());
    }
}
using System;

public class EstadoAtacar : IEstado
{
    public void Executar(Inimigo inimigo)
    {
        Console.WriteLine("Inimigo está atacando!");
        inimigo.MudarEstado(new EstadoPatrulha());
    }
}
public class Inimigo
{
    private IEstado estadoAtual;

    public Inimigo()
    {
        estadoAtual = new EstadoPatrulha(); // Começa patrulhando
    }

    public void MudarEstado(IEstado novoEstado)
    {
        estadoAtual = novoEstado;
    }

    public void Atualizar()
    {
        estadoAtual.Executar(this);
    }
}
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Inimigo inimigo = new Inimigo();

        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"\n--- Ciclo {i + 1} ---");
            inimigo.Atualizar();
            Thread.Sleep(1000);
        }
    }
}
