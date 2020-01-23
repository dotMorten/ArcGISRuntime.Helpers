using System;
using Esri.ArcGISRuntime.Mapping;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class Elevation
    {
        public static Surface CreateWorldElevationSurface()
        {
            var surface = new Surface() { Name = "World Elevation Service" };
            surface.AddWorldElevationService();
            return surface;
        }

        public static ElevationSource CreateWorldElevationSource() => new ArcGISTiledElevationSource(new Uri(ArcGISOnlineServices.WorldElevationServiceUri));

        public static void AddWorldElevationService(this Surface surface)
        {
            surface.ElevationSources.Insert(0, CreateWorldElevationSource());
        }
    }
}
