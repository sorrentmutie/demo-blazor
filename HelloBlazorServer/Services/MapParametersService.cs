using Blazor.Library.Map;

namespace HelloBlazorServer.Services;

public class MapParametersService : IMapParameters
{
    public List<MapParameters> GetParameters()
    { 
        var mapMarkers = new List<MapMarker>();
        mapMarkers.Add(new MapMarker { Id = 1, MapCoordinates = new MapCoordinates { Latitude = 49.01, Longitude = 10.01}, Description = "desc1" });
        mapMarkers.Add(new MapMarker { Id = 2, MapCoordinates = new MapCoordinates { Latitude = 49.02, Longitude = 10.02 }, Description = "desc2" });

        var parameters = new List<MapParameters>();
        parameters.Add(new MapParameters { Id = "map1", 
                                            Height = "200", 
                                            Coordinates = new MapCoordinates { Latitude = 49.0, Longitude = 10.0 },     
                                            Zoom = 10,
                                            Markers = mapMarkers });
        parameters.Add(new MapParameters { Id = "map2", Height = "200", Coordinates = new MapCoordinates { Latitude = 41, Longitude = 16 }, Zoom = 10 });
        return parameters;
    }
}
