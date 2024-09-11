using Microsoft.JSInterop;

namespace Blazor.UI.Library.Interop;

public class MyChartInterop : IAsyncDisposable
{
    private readonly IJSRuntime jSRuntime;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MyChartInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
              "import", "./_content/Blazor.UI.Library/chart.js").AsTask());
    }

    public async Task ShowChart()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showChart");
    }

    public async Task ShowChart2(string Id)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showChart2", Id);
    }

    public async Task ShowChart3(string Id, ChartType Type)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showChart3", Id, Type.ToString());
    }


    public async Task ShowChartLine(string Id, ChartData Data)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showChartLine", Id, Data);
    }

    public async Task ShowChartBar(string Id, ChartData Data)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showChartBar", Id, Data);
    }

    public async Task ShowChartPie(string Id, DataPie Data)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showChartPie", Id, Data);
    }


    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
