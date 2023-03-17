// See https://aka.ms/new-console-template for more information

using RoboAco.Events;
using RoboAco.Monitores;

public class Program
{

    public static void Main(string[] args)
    {
        // preco medio n eventos -- ((n-1)*(valor anterior) + valor atual) / n

        var monitor = new BrMonitor();
        var preco_medio = new CandleSticks("ITSA4");
    }
}