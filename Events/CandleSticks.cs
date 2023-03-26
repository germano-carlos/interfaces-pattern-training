using RoboAco.Classes.Controllers;

namespace RoboAco.Events;

//olha preco de compra, preco de venda, acima, abaixo, e ve se ta hora de comprar/vender
public class CandleSticks : BaseWrapper
{
    public CandleSticks(string name) : base(name)
    {
        
    }
    
    public override void OnPriceChanged(string monitor, string ativo, double valor)
    {
        if (!(valor > CurrentStockPrice) && !(valor < CurrentStockPrice) && CurrentStockPrice is not null) return;
        CurrentStockPrice = valor;
        
        var rnd = new Random();
        var randomValue = rnd.Next(2);
        
        Logger.Logar($"[CS] - O ativo[{ativo}] teve seu preço médio alterado de {CurrentStockPrice} para {valor}", "onPriceChanged");
        
        switch (randomValue)
        {
            case 1:
                Logger.Logar($"[CS] - Vendendo ações do ativo[{ativo}] à R$ {CurrentStockPrice}", "venda");
                Console.WriteLine("O preço da ação esta superior ao valor máximo definido, vendendo ações");
                CentralMonitoramento.Vender(monitor, StockName);
                break;
            case 0:
                Logger.Logar($"[CS] - Comprando ações do ativo[{ativo}] à R$ {CurrentStockPrice}", "compra");
                Console.WriteLine("O preço da ação esta inferior ao valor mínimo definido, comprando ações");
                CentralMonitoramento.Comprar(monitor, StockName);
                break;
        }
    }
    
    // montar o grafico em JPEG
    public void Print()
    {
        throw new NotImplementedException();
    }
}