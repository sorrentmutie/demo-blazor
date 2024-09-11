using Blazor.Library.Charts.Interfaces;
using Blazor.UI.Library.Interop;
using System.Net.Http.Json;

namespace HelloBlazorWebAssembly.Services;

public class ChartServiceWasm : IDataChart
{
    private readonly HttpClient httpClient;
    private string url = "charts";

    public ChartServiceWasm(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<ChartData>?> GetDataAsync()
    {
        var responseMessage = await httpClient.GetAsync(url);
        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<List<ChartData>>();
        }
        else
        {
            return null;
        }
    }
}
