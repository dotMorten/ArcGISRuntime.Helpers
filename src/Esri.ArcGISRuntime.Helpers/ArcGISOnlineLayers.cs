using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Portal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class ArcGISOnlineLayers
    {
        public static Task<Layer> CreateMidCenturyVectorLayer() => CreateLayer(ArcGISOnlineServices.MidCenturyVectorItem);

        public static Task<Layer> CreateOpenStreetMapVectorBlueprintLayer() => CreateLayer(ArcGISOnlineServices.OpenStreetMapVectorBlueprintItem);

        public static Task<Layer> CreateOpenStreetMapVectorReliefItemLayer() => CreateLayer(ArcGISOnlineServices.OpenStreetMapVectorReliefItem);

        private static async Task<Layer> CreateLayer(Task<PortalItem> itemTask) => (await itemTask.ConfigureAwait(false)).AsLayer();
    }
}
