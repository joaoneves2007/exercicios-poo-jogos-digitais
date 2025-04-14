using System;

public class EstadoDoJogo
{
    private static EstadoDoJogo instancia;

    public int NivelAtual { get; set; }
    public int Pontuacao { get; set; }
    public int VidasRestantes { get; set; }

    private EstadoDoJogo()
    {
        NivelAtual = 1;
        Pontuacao = 0;
        VidasRestantes = 3;
    }

    public static EstadoDoJogo Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new EstadoDoJogo();
            }
            return instancia;
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"Nível: {NivelAtual}, Pontuação: {Pontuacao}, Vidas: {VidasRestantes}");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        EstadoDoJogo estado1 = EstadoDoJogo.Instancia;
        estado1.MostrarEstado();

        estado1.NivelAtual = 2;
        estado1.Pontuacao += 150;
        estado1.VidasRestantes--;

        EstadoDoJogo estado2 = EstadoDoJogo.Instancia;
        estado2.MostrarEstado();

        Console.WriteLine($"Mesma instância? {estado1 == estado2}");
    }
}