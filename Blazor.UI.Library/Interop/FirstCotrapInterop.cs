using Microsoft.JSInterop;

namespace Blazor.UI.Library.Interop;

public class FirstCotrapInterop
{
    private readonly IJSRuntime jSRuntime;

    public FirstCotrapInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task<int> Somma(int a, int b)
    {
        return await jSRuntime.InvokeAsync<int>("Somma", a, b);
    }

    public async Task Saluta(string nome)
    {
        await jSRuntime.InvokeVoidAsync("saluta", nome);
    }
    
}
