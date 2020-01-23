using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Esri.ArcGISRuntime.Helpers.Tests
{
    [TestClass]
    public class Elevation
    {
        [TestMethod]
        public async Task CreateWorldElevationService()
        {
            var svc = Esri.ArcGISRuntime.Helpers.Elevation.CreateWorldElevationService();
            await svc.LoadAsync();
        }
    }
}
