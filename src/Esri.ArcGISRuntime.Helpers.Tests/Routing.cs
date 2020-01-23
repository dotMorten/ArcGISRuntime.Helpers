using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Esri.ArcGISRuntime.Helpers.Tests
{
    [TestClass]
    public class Routing
    {
        string username = "";
        string password = "";
        
        [TestMethod]
        public async Task GetDirections()
        {
            await WorldRouting.InitializeAsync(username, password);
            var route = await WorldRouting.GetRouteAsync(GeometryHelpers.FromLatLong(34.2, -117.1), GeometryHelpers.FromLatLong(34.22, -117.14));
            Assert.IsNotNull(route);
            var route2 = await WorldRouting.GetRouteAsync("380 New York St, Redlands", "Las Vegas, NV");
            Assert.IsNotNull(route2);
        }

        [TestMethod]
        public async Task GetDirectionsViaPortal()
        {
            var portalUri = new Uri("https://www.arcgis.com/sharing/rest/");
            await WorldRouting.InitializeAsync(portalUri, username, password);
            var route = await WorldRouting.GetRouteAsync(GeometryHelpers.FromLatLong(34.2, -117.1), GeometryHelpers.FromLatLong(34.22, -117.14));
            Assert.IsNotNull(route);
        }
    }
}
