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
        var randomValue = rnd.Next(0, 1);
        
        switch (randomValue)
        {
            case 1:
                Console.WriteLine("O preço da ação esta superior ao valor máximo definido, vendendo ações");
                CentralMonitoramento.Vender(monitor, StockName);
                break;
            case 0:
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