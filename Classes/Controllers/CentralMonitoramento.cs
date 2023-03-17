using RoboAco.Classes.Interfaces;

namespace RoboAco.Classes.Controllers;

// Registrar todos 
// Uma thread que varre os monitores e checka o preço
public static class CentralMonitoramento
{
    private static Dictionary<string, IBolsa> monitores = new();
    private static Thread thread = new (VerificaTodos);

    public static void Registry(IBolsa monitor)
    {
        monitores.TryAdd(monitor.Name, monitor);
    }

    static CentralMonitoramento()
    {
        thread.Start();
    }

    public static void AdicionarAtivoMonitorar(string ativo)
    {
        foreach (var m in monitores.Values)
        {
            m.MonitorarAtivo(ativo);
        }
    }

    private static void VerificaTodos()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Vamos buscar Preço !!");
                foreach (var m in monitores.Values)
                {
                    m.VerificarPreco();
                }
            }
            finally
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }

    public static void Comprar(string monitorName, string ativo)
    {
        var monitor = monitores.First(s => s.Key == monitorName).Value;
        monitor.Compra(ativo);
    }

    public static void Vender(string monitorName, string ativo)
    {
        var monitor = monitores.First(s => s.Key == monitorName).Value;
        monitor.Vender(ativo);
    }
}