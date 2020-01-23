using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Esri.ArcGISRuntime.Helpers.Tests
{
    [TestClass]
    public class Layers
    {
        [TestMethod]
        public async Task MidCenturyVectorLayer()
        {
            var layer = await ArcGISOnlineLayers.CreateMidCenturyVectorLayer();
            await layer.LoadAsync();
        }

        [TestMethod]
        public async Task OpenStreetMapVectorBlueprintLayer()
        {
            var layer = await ArcGISOnlineLayers.CreateOpenStreetMapVectorBlueprintLayer();
            await layer.LoadAsync();
        }


        [TestMethod]
        public async Task OpenStreetMapVectorReliefItemLayer()
        {
            var layer = await ArcGISOnlineLayers.CreateOpenStreetMapVectorReliefItemLayer();
            await layer.LoadAsync();
        }
    }
}
