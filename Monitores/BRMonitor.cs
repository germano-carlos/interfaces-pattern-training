using RoboAco.Classes;
using RoboAco.Classes.Controllers;
using RoboAco.Classes.Interfaces;
using RoboAco.Util;

namespace RoboAco.Monitores;

public class BrMonitor : IBolsa
{
    // defniir uma lista de ações ou uma para cada ação
    private HashSet<string> ListaAtivos = new();

    public BrMonitor()
    {
        CentralMonitoramento.Registry(this);
    }

    public string Name { get; set; } = "BR";

    public void MonitorarAtivo(string ativo)
    {
        if (true) // condição pra checar se ação da bolsa brasileira
            ListaAtivos.Add(ativo);
        else
        {
            throw new Exception("Não é da bolsa brasileira");
        }
    }

    public void VerificarPreco()
    {
        foreach (var ativo in ListaAtivos)
        {
            var api = BrApi.GetDetails(ativo);
            CentralEventos.Emit(Name, ativo, api.results.First().regularMarketPrice);
        }
    }

    public void Compra(string ativo)
    {
        Console.WriteLine("Estou comprando ações deste ativo = " + ativo);
    }

    public void Vender(string ativo)
    {
        Console.WriteLine("Estou vendendo ações deste ativo = " + ativo);
    }
}