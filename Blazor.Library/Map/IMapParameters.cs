namespace Blazor.Library.Map;

public interface IMapParameters
{
    public List<MapParameters> GetParameters();
    public Task<List<MapParameters>?> GetParametersAsync();
}
