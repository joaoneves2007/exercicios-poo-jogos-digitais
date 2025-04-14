public static class EventosDoJogo
{
    public delegate void EventoImportante(string mensagem);

    public static event EventoImportante AoDerrotarChefe;
    public static event EventoImportante AoSubirNivel;
    public static event EventoImportante AoCompletarMissao;

    public static void DispararChefeDerrotado()
    {
        AoDerrotarChefe?.Invoke("O chefe final foi derrotado! Uma nova área foi desbloqueada.");
    }

    public static void DispararNivelUp()
    {
        AoSubirNivel?.Invoke("O jogador subiu de nível! Novas habilidades foram desbloqueadas.");
    }

    public static void DispararMissaoConcluida()
    {
        AoCompletarMissao?.Invoke("Missão concluída! Recompensa recebida.");
    }
}
using System;

public class Jogo
{
    public void Iniciar()
    {
        EventosDoJogo.AoDerrotarChefe += MensagemEvento;
        EventosDoJogo.AoSubirNivel += MensagemEvento;
        EventosDoJogo.AoCompletarMissao += MensagemEvento;

        Console.WriteLine(">>> Jogo iniciado...\n");

        EventosDoJogo.DispararMissaoConcluida();
        EventosDoJogo.DispararNivelUp();
        EventosDoJogo.DispararChefeDerrotado();
    }

    private void MensagemEvento(string mensagem)
    {
        Console.WriteLine($"[EVENTO] {mensagem}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Jogo jogo = new Jogo();
        jogo.Iniciar();
    }
}