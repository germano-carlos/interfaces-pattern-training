// See https://aka.ms/new-console-template for more information

using RoboAco.Events;
using RoboAco.Monitores;

public class Program
{

    public static void Main(string[] args)
    {
        // preco medio n eventos -- ((n-1)*(valor anterior) + valor atual) / n

        var monitor = new BrMonitor();
        var preco_medio = new AlarmePrecoMedio("ITSA4", 7,10);
        var preco_medio2 = new Stop("ITSA4", 7,10);
        var preco_medio3 = new Stop("HAPV3F", 7,10);
    }
}