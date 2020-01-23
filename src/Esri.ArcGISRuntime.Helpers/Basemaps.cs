using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class BasemapExtensions
    {
        public static Map WithBasemap(this Map map, BasemapType type)
        {
            map.Basemap = FromBasemapType(type);
            return map;
        }

        public static Scene WithBasemap(this Scene scene, BasemapType type)
        {
            scene.Basemap = FromBasemapType(type);
            return scene;
        }

        public static Basemap FromBasemapType(this BasemapType type)
        {
            switch(type)
            {
                case BasemapType.DarkGrayCanvasVector: return Basemap.CreateDarkGrayCanvasVector();
                case BasemapType.Imagery: return Basemap.CreateImagery();
                case BasemapType.ImageryWithLabels: return Basemap.CreateImageryWithLabels();
                case BasemapType.ImageryWithLabelsVector: return Basemap.CreateImageryWithLabelsVector();
                case BasemapType.LightGrayCanvas: return Basemap.CreateLightGrayCanvas();
                case BasemapType.LightGrayCanvasVector: return Basemap.CreateLightGrayCanvasVector();
                case BasemapType.NationalGeographic: return Basemap.CreateNationalGeographic();
                case BasemapType.NavigationVector: return Basemap.CreateNavigationVector();
                case BasemapType.Oceans: return Basemap.CreateOceans();
                case BasemapType.OpenStreetMap: return Basemap.CreateOpenStreetMap();
                case BasemapType.Streets: return Basemap.CreateStreets();
                case BasemapType.StreetsNightVector: return Basemap.CreateStreetsNightVector();
                case BasemapType.StreetsVector: return Basemap.CreateStreetsVector();
                case BasemapType.StreetsWithReliefVector: return Basemap.CreateStreetsWithReliefVector();
                case BasemapType.TerrainWithLabels: return Basemap.CreateTerrainWithLabels();
                case BasemapType.TerrainWithLabelsVector: return Basemap.CreateTerrainWithLabelsVector();
                case BasemapType.Topographic: return Basemap.CreateTopographic();
                case BasemapType.TopographicVector: return Basemap.CreateTopographicVector();
                default: throw new NotImplementedException(type.ToString());
            }
        }
    }
}
