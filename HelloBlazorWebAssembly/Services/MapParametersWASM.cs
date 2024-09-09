using Blazor.Library.Map;
using Blazor.Library.Northwind.DTO;
using System;
using System.Net.Http.Json;

namespace HelloBlazorWebAssembly.Services;

public class MapParametersWASM : IMapParameters
{
    private readonly HttpClient httpClient;
    private string url = "mapparameters";

    public MapParametersWASM(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public List<MapParameters> GetParameters()
    {
        throw new NotImplementedException();
    }

    public async Task<List<MapParameters>?> GetParametersAsync()
    {
        var responseMessage = await httpClient.GetAsync(url);
        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<List<MapParameters>>();
        }
        else
        {
            return null;
        }
    }
}
