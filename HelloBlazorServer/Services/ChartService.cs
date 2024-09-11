using Blazor.Library.Charts.Interfaces;
using Blazor.UI.Library.Interop;

namespace HelloBlazorServer.Services;

public class ChartService : IDataChart
{
    public async Task<List<ChartData>?> GetDataAsync()
    {
        List<ChartData> dataList = new List<ChartData>();

        ChartData data = new ChartData
        {
            Id = "chart1",
            Labels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri" },
            Series = new List<List<int>>
            {
                new List<int> { 1, 1, 1, 1, 0 },
                new List<int> { 11, 21, 31, 41, 50 }
            }
        };

        ChartData data2 = new ChartData
        {
            Id = "chart2",
            Labels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri" },
            Series = new List<List<int>>
            {
                new List<int> { 31, 31,31, 31, 30 },
                new List<int> { 11, 21, 31, 41, 50 }
            }
        };

        dataList.Add(data);
        dataList.Add(data2);

        await Task.Delay(100);

        return dataList;
    }
}
