using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Esri.ArcGISRuntime.Helpers.Tests
{
    [TestClass]
    public class Geocoding
    {
        [TestMethod]
        public async Task GetAddress()
        {
            var results = await WorldGeocoder.GeocodeAsync("380 New York St, Redlands, CA");
            var location = results[0].DisplayLocation;
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            var result = results[0];
            Assert.AreEqual(-117.1956764921524, result.RouteLocation.X, 0.000001);
            Assert.AreEqual(34.05722922814357, result.RouteLocation.Y, 0.000001);
            Assert.AreEqual(4326, result.RouteLocation.SpatialReference.Wkid);
        }

        [TestMethod]
        public async Task ReverseGeocode()
        {
            var results = await WorldGeocoder.ReverseGeocodeAsync(GeometryHelpers.FromLatLong(34.05722922814357, -117.1956764921524));
            var address = results[0].Label;
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            var result = results[0];
            Assert.IsTrue(result.Label.Contains("New York St"), $"Expected '*New York St*', but got {result.Label}");
        }
    }
}
