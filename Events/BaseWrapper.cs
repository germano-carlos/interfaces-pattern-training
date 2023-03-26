using RoboAco.Classes.Controllers;
using RoboAco.Classes.Interfaces;
using RoboAco.Loggers;

namespace RoboAco.Events;

public abstract class BaseWrapper : IEventos
{
    protected string StockName { get; set; }
    protected double? CurrentStockPrice { get; set; }
    protected ILog Logger = new DBLog();

    protected BaseWrapper(string ativo)
    {
        StockName = ativo;
        
        CentralEventos.Registry(StockName, this);
        CentralMonitoramento.AdicionarAtivoMonitorar(StockName);
    }
    public abstract void OnPriceChanged(string monitor, string ativo, double valor);
}