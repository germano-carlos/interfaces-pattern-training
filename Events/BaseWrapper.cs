using RoboAco.Classes.Controllers;
using RoboAco.Classes.Interfaces;

namespace RoboAco.Events;

public class BaseWrapper : IEventos
{
    protected string StockName { get; set; }
    protected double? CurrentStockPrice { get; set; }

    protected BaseWrapper(string ativo)
    {
        StockName = ativo;
        
        CentralEventos.Registry(StockName, this);
        CentralMonitoramento.AdicionarAtivoMonitorar(StockName);
    }

    public virtual void OnPriceChanged(string monitor, string ativo, double valor)
    {
        throw new NotImplementedException();
    }
}