using RoboAco.Classes.Controllers;

namespace RoboAco.Events;

// saber o intervalo de frequencia
// entender os patterns de abertura/fechamento dos candlesticks

public class Fibonacci : BaseWrapper
{
    public double Interval { get; set; }

    public Fibonacci(string name, double interval) : base(name)
    {
        Interval = interval;
    }

    public override void OnPriceChanged(string monitor, string ativo, double valor)
    {
        if (!(valor > CurrentStockPrice) && !(valor < CurrentStockPrice) && CurrentStockPrice is not null) return;
        CurrentStockPrice = valor;
        //CurrentStockPrice++;        
        var rnd = new Random();
        var randomValue = rnd.Next(2);
        
        Logger.Logar($"[FIB] - O ativo[{ativo}] teve seu preço médio alterado de {CurrentStockPrice} para {valor}", "onPriceChanged");
        
        switch (randomValue)
        {
            case 1:
                Logger.Logar($"[FIB] - Vendendo ações do ativo[{ativo}] à R$ {CurrentStockPrice}", "venda");
                Console.WriteLine("O preço da ação esta superior ao valor máximo definido, vendendo ações");
                CentralMonitoramento.Vender(monitor, StockName);
                break;
            case 0:
                Logger.Logar($"[FIB] - Comprando ações do ativo[{ativo}] à R$ {CurrentStockPrice}", "compra");
                Console.WriteLine("O preço da ação esta inferior ao valor mínimo definido, comprando ações");
                CentralMonitoramento.Comprar(monitor, StockName);
                break;
        }
    }
}