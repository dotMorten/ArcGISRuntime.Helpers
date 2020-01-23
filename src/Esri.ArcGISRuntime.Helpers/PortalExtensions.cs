using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Portal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class PortalExtensions
    {
        public static Layer AsLayer(this PortalItem item)
        {
            switch (item.Type)
            {
                case PortalItemType.VectorTileService: return new ArcGISVectorTiledLayer(item);
                case PortalItemType.MapService: return new ArcGISTiledLayer(item);
                case PortalItemType.KML: return new KmlLayer(item);
                case PortalItemType.SceneService: return new ArcGISSceneLayer(item);
                case PortalItemType.FeatureCollection: return new FeatureCollectionLayer(new Data.FeatureCollection(item));
                case PortalItemType.WMS: return new WmsLayer(item);
            }
            throw new ArgumentException($"Type {item.Type} not supported");
        }

        public static bool IsLayerType(this PortalItem item)
        {
            switch (item.Type)
            {
                case PortalItemType.VectorTileService:
                case PortalItemType.MapService:
                case PortalItemType.KML:
                case PortalItemType.SceneService:
                case PortalItemType.FeatureCollection:
                case PortalItemType.WMS:
                    return true;
            }
            return false;
        }
    }
}
