namespace Blazor.UI.Library.Interop;

//public class ChartData
//{
//    public List<string> Labels { get; set; } = new();

//    public List<SeriesData> Data { get; set; } = new();
//}


//public class SeriesData
//{
//    public List<double> Series { get; set; } = new();
//}

public class ChartData
{
    public string? Id { get; set; }
    public List<string> Labels { get; set; }
    public List<List<int>> Series { get; set; }

    public ChartData()
    {
        Labels = new List<string>();
        Series = new List<List<int>>();
    }
}

public class DataPie
{
    public List<int> Series { get; set; }
}