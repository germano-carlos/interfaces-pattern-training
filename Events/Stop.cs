using RoboAco.Classes.Controllers;

namespace RoboAco.Events;

public class Stop : AlarmePrecoMedio
{
    public Stop(string name, double min, double max) : base(name, min, max)
    {
    }

    public override void OnPriceChanged(string monitor, string ativo, double valor)
    {
        if (!(valor > CurrentStockPrice) && !(valor < CurrentStockPrice) && CurrentStockPrice is not null) return;
        
        Console.WriteLine($"O ativo[{ativo}] teve seu preço médio alterado de {CurrentStockPrice} para {valor}");
        Logger.Logar($"[APM] - O ativo[{ativo}] teve seu preço médio alterado de {CurrentStockPrice} para {valor}", "onPriceChanged");
        CurrentStockPrice = valor;
        
        if (CurrentStockPrice > MaxValue)
        {
            Console.WriteLine("O preço da ação esta superior ao valor máximo definido, vendendo ações");
            Logger.Logar($"[APM] - Vendendo ações do ativo[{ativo}] à R$ {CurrentStockPrice}", "venda");
            CentralMonitoramento.Vender(monitor, StockName);
        }
        else if (CurrentStockPrice < MinValue)
        {
            Logger.Logar($"[APM] - Comprando ações do ativo[{ativo}] à R$ {CurrentStockPrice}", "compra");
            Console.WriteLine("O preço da ação esta inferior ao valor mínimo definido, comprando ações");
            CentralMonitoramento.Comprar(monitor, StockName);
        }
    }
}