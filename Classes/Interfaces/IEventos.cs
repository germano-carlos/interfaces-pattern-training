namespace RoboAco.Classes.Interfaces;


// as seguintes classes implementam essa interface: fibonnaci, candlesticks e preço medio, alerme de preco medio, print na tela no console
public interface IEventos
{
    public void OnPriceChanged(string monitor, string ativo, double valor);
}