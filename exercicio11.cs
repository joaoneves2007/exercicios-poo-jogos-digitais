using System;

public class Personagem2D
{
    public float PosicaoY { get; private set; }
    public float VelocidadeY { get; private set; }
    public bool NoChao { get; private set; }

    private const float GRAVIDADE = -9.8f;
    private const float FORCA_PULO = 15f;
    private const float TEMPO_DELTA = 0.1f; // Simulação de tempo (100ms por "frame")
    private const float CHAO_Y = 0f;

    public Personagem2D()
    {
        PosicaoY = CHAO_Y;
        VelocidadeY = 0;
        NoChao = true;
    }

    public void Pular()
    {
        if (NoChao)
        {
            VelocidadeY = FORCA_PULO;
            NoChao = false;
            Console.WriteLine("Personagem pulou!");
        }
    }

    public void AtualizarFisica()
    {
        if (!NoChao)
        {
            VelocidadeY += GRAVIDADE * TEMPO_DELTA;
            PosicaoY += VelocidadeY * TEMPO_DELTA;

            if (PosicaoY <= CHAO_Y)
            {
                PosicaoY = CHAO_Y;
                VelocidadeY = 0;
                NoChao = true;
                Console.WriteLine("Personagem aterrissou no chão.");
            }
        }
    }

    public void Andar()
    {
        Console.WriteLine("Personagem andou para o lado.");
    }

    public void MostrarStatus()
    {
        Console.WriteLine($"Posição Y: {PosicaoY:F2} | Velocidade Y: {VelocidadeY:F2} | No chão: {NoChao}");
    }
}
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Personagem2D personagem = new Personagem2D();

        personagem.Andar();
        personagem.Pular();

        for (int i = 0; i < 30; i++)
        {
            personagem.AtualizarFisica();
            personagem.MostrarStatus();
            Thread.Sleep(100); // Espera 100ms para simular tempo real
        }
    }
}
