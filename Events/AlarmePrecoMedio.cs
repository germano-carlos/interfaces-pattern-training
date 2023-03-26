using RoboAco.Util;

namespace RoboAco.Events;


// alarme preco medio vai dar um bip se o preco medio for maior que tanto ou menor que tanto !
// string nome ativo, min, max
public class AlarmePrecoMedio : BaseWrapper
{
    protected double MinValue { get; set; }
    protected double MaxValue { get; set; }

    public AlarmePrecoMedio(string name, double min, double max) : base(name)
    {
        MinValue = min;
        MaxValue = max;
    }

    public override void OnPriceChanged(string monitor, string ativo, double valor)
    {
        if (!(valor > CurrentStockPrice) && !(valor < CurrentStockPrice) && CurrentStockPrice is not null) return;
        //CurrentStockPrice++;
        
        Logger.Logar($"[APM] - O ativo[{ativo}] teve seu preço médio alterado de {CurrentStockPrice} para {valor}", "onPriceChanged");
        Console.WriteLine($"O preço médio mudou de {CurrentStockPrice} para {valor}");
        CurrentStockPrice = valor;
    }
}