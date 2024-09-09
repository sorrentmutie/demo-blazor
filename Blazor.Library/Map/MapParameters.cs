namespace Blazor.Library.Map;

public class MapParameters
{
    required public string Id { get; set; }
    public string? Height { get; set; } = "500";
    public MapCoordinates Coordinates { get; set; } = new MapCoordinates();
    public int Zoom { get; set; } = 10;
    public List<MapMarker> Markers { get; set; } = new List<MapMarker>();
}
