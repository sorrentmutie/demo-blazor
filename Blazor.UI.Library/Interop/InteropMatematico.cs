using Microsoft.JSInterop;

namespace Blazor.UI.Library.Interop;

public class InteropMatematico : IAsyncDisposable
{
    private readonly IJSRuntime jSRuntime;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    private readonly Lazy<Task<IJSObjectReference>> moduleTaskConstants;
    private DotNetObjectReference<Helper>? helperJs;


    public InteropMatematico(IJSRuntime jSRuntime) 
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Blazor.UI.Library/MathFunctions.js").AsTask());

        moduleTaskConstants = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Blazor.UI.Library/Constants.js").AsTask());
    }

    public async Task<double> CalcolaAreaTriangolo(double baseTriangolo, double altezzaTriangolo)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<double>("calcolaAreaTriangolo", baseTriangolo, altezzaTriangolo);
    }

    public async Task<double> CalcolaAreaQuadrato(double lato)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<double>("calcolaAreaQuadrato", lato);
    }

   public async Task<double> CalcolaAreaCerchio(double raggio)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<double>("calcolaAreaCerchio", raggio);
    }   

    public async Task Somma(int a, int b)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("faiQualcosaConCSharp", a, b);
    }

    public async Task Saluta(string nome)
    {
        var helper = new Helper(nome);
        helperJs = DotNetObjectReference.Create(helper);
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("saluta", helperJs);
    }



    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }

        if(moduleTaskConstants.IsValueCreated)
        {

            var module = await moduleTaskConstants.Value;
            await module.DisposeAsync();
        }

        if(helperJs != null)
        {
            helperJs.Dispose();
        }
    }
}
