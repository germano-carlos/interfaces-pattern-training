namespace RoboAco.Classes.StockAPI;

public class StockItemList
{
    public List<StockItem> stocks { get; set; }
}
public class StockItem

{
    public string stock { get; set; }
    public string name { get; set; }
    public string close { get; set; }
    public string change { get; set; }
    public string volume { get; set; }
    public string market_cap { get; set; }
    public string logo { get; set; }
    public string sector { get; set; }
}