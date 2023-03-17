using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RoboAco.Classes.StockAPI;

namespace RoboAco.Util;

public static class BrApi
{
    private static readonly string _url = "https://brapi.dev/api/quote";

    public static GetRoot GetDetails(string ticker)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, _url + '/' + ticker + "?range=1d&interval=1d&fundamental=false&dividends=false");
        var response = client.Send(request);
        response.EnsureSuccessStatusCode();

        var s = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<GetRoot>(s)!;
    }

    public static StockItemList StockList()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, _url + "/list?sortBy=change&sortOrder=desc&limit=10");
        var response = client.Send(request);
        response.EnsureSuccessStatusCode();

        var s = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<StockItemList>(s)!;
    }
    
    
    
}