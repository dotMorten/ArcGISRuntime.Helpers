using System;
using Esri.ArcGISRuntime.Mapping;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class Elevation
    {
        public static Surface CreateWorldElevationSurface()
        {
            var surface = new Surface() { Name = "World Elevation Service" };
            return surface.WithWorldElevationService();
        }

        public static ElevationSource CreateWorldElevationSource() => new ArcGISTiledElevationSource(new Uri(ArcGISOnlineServices.WorldElevationServiceUri));

        public static Surface WithWorldElevationService(this Surface surface)
        {
            surface.ElevationSources.Insert(0, CreateWorldElevationSource());
            return surface;
        }

        public static Scene WithWorldElevationService(this Scene scene)
        {
            scene.BaseSurface.WithWorldElevationService();
            return scene;
        }
    }
}
