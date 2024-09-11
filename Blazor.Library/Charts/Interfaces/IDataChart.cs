using Blazor.UI.Library.Interop;

namespace Blazor.Library.Charts.Interfaces;

public interface IDataChart
{
    public Task<List<ChartData>?> GetDataAsync();
}
