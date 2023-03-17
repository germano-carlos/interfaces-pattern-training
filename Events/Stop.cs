using RoboAco.Classes.Controllers;

namespace RoboAco.Events;

public class Stop : AlarmePrecoMedio
{
    public Stop(string name, double min, double max) : base(name, min, max)
    {
    }

    public override void OnPriceChanged(string monitor, string ativo, double valor)
    {
        CurrentStockPrice++;
        if (!(valor > CurrentStockPrice) && !(valor < CurrentStockPrice) && CurrentStockPrice is not null) return;
        
        Console.WriteLine($"O preço médio mudou de {CurrentStockPrice} para {valor}");
        CurrentStockPrice = valor;
        
        if (CurrentStockPrice > MaxValue)
        {
            Console.WriteLine("O preço da ação esta superior ao valor máximo definido, vendendo ações");
            CentralMonitoramento.Vender(monitor, StockName);
        }
        else if (CurrentStockPrice < MinValue)
        {
            Console.WriteLine("O preço da ação esta inferior ao valor mínimo definido, comprando ações");
            CentralMonitoramento.Comprar(monitor, StockName);
        }
    }
}