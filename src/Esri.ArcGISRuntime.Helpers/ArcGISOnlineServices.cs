using System;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Portal;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class ArcGISOnlineServices
    {
        public static string WorldGeocodeServiceUri { get; } = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer";
        public static string WorldRoutingServiceUri { get; } = "https://route.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World";
        public static string WorldElevationServiceUri { get; } = "https://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer";
      
        public static Task<ArcGISPortal> ArcGISOnlinePortal { get; } = ArcGISPortal.CreateAsync();
        private static async Task<PortalItem> CreateItem(string itemId)
        {
            return await PortalItem.CreateAsync(await ArcGISOnlinePortal.ConfigureAwait(false), itemId).ConfigureAwait(false);
        }
        public static Task<PortalItem> WorldElevationServiceItem { get; } = CreateItem("e393da08765940e49e27e30e1df02b58");
        public static Task<PortalItem> OpenStreetMapVectorReliefItem { get; } = CreateItem("8f9cb35cec274e25b4c5d6add631f1f0");
        public static Task<PortalItem> OpenStreetMapVectorBlueprintItem { get; } = CreateItem("80be160f0ca1413d898ad4e90d197278");
        public static Task<PortalItem> MidCenturyVectorItem { get; } = CreateItem("7675d44bb1e4428aa2c30a9b68f97822");
    }
}
