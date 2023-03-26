// See https://aka.ms/new-console-template for more information

using RoboAco.Events;
using RoboAco.Model;
using RoboAco.Model.NSLog;
using RoboAco.Monitores;

public class Program
{

    public static void Main(string[] args)
    {
        using var context = RoboAcaoContext.Get("Main");

        var monitor = new BrMonitor();
        var e = new Fibonacci("ITSA4", 5);
        var x = new AlarmePrecoMedio("ITSA4", 7, 10);
        
        var e2 = new Fibonacci("HAPV3F", 5);
        var x2 = new AlarmePrecoMedio("HAPV3F", 7, 10);
        
        context.SaveChanges();
    }
}