﻿using RoboAco.Classes.Controllers;

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
}