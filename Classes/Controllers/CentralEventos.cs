using System.Collections.Concurrent;
using RoboAco.Classes.Interfaces;

namespace RoboAco.Classes.Controllers;

public class CentralEventos
{
    private static ConcurrentDictionary<string, IEventos> Events = new ();

    public static void Registry(string ativo, IEventos e)
    {
        Events.TryAdd(ativo + '-' + e.GetType().Name, e);
    }
    
    public static void Emit(string monitor, string ativo, double valor)
    {
        foreach (var l in Events.Where(s => s.Key.Contains(ativo+'-')))
        {
            l.Value.OnPriceChanged(monitor, ativo, valor);
        }
    }
}