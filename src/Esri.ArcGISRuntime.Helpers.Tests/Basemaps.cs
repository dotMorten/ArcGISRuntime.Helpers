using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Esri.ArcGISRuntime.Helpers;
using Esri.ArcGISRuntime.Mapping;

namespace Esri.ArcGISRuntime.Helpers.Tests
{
    [TestClass]
    public class Basemaps
    {
        [TestMethod]
        public void WithMap()
        {
            var map = new Map().WithBasemap(BasemapType.StreetsNightVector);
            Assert.IsNotNull(map.Basemap);
            Assert.IsTrue(map.Basemap.BaseLayers.Count > 0);
            Assert.IsInstanceOfType(map.Basemap.BaseLayers[0], typeof(ArcGISVectorTiledLayer));
        }

        [TestMethod]
        public void WithScene()
        {
            var scene = new Scene().WithBasemap(BasemapType.Imagery).WithWorldElevationService();
            Assert.IsNotNull(scene.Basemap);
            Assert.IsTrue(scene.Basemap.BaseLayers.Count > 0);
            Assert.IsInstanceOfType(scene.Basemap.BaseLayers[0], typeof(ArcGISTiledLayer));
            Assert.IsTrue(scene.BaseSurface.ElevationSources.Count == 1);
            Assert.IsInstanceOfType(scene.BaseSurface.ElevationSources[0], typeof(ArcGISTiledElevationSource));
        }
    }
}
