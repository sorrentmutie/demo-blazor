namespace Blazor.Library.Map;

public class MapMarker
{
    public int Id { get; set; }
    public MapCoordinates MapCoordinates { get; set; } = new MapCoordinates();
    public string? Description { get; set; }
}
