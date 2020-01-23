using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class WorldRouting
    {
        private static RouteTask? _routeTask;

        public static bool IsInitialized => _routeTask != null;

        public static Task InitializeAsync() => InitializeAsync(credential: null);

        public static async Task InitializeAsync(string username, string password)
        {
            var credential = await AuthenticationManager.Current.GenerateCredentialAsync(new Uri(ArcGISOnlineServices.WorldRoutingServiceUri), username, password).ConfigureAwait(false);
            await InitializeAsync(credential).ConfigureAwait(false);
        }

        public static async Task InitializeAsync(Credential? credential)
        {
            _routeTask = await RouteTask.CreateAsync(new Uri(ArcGISOnlineServices.WorldRoutingServiceUri), credential).ConfigureAwait(false);
        }

        public static async Task InitializeAsync(Uri portalUri, string username, string password)
        {
            var credential = await Esri.ArcGISRuntime.Security.AuthenticationManager.Current.GenerateCredentialAsync(portalUri, username, password).ConfigureAwait(false);
            var portal = await Portal.ArcGISPortal.CreateAsync(portalUri, credential).ConfigureAwait(false);
            await InitializeAsync(portal).ConfigureAwait(false);
        }

        public static async Task InitializeAsync(Portal.ArcGISPortal portal)
        {
            string? url = portal.PortalInfo.HelperServices.RouteService?.Url;
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("The provided portal does not have a routing service configured");
            var c = portal.Credential;
            if (c == null)
                throw new ArgumentException("User does not have a credential");
            _routeTask = await RouteTask.CreateAsync(new Uri(url), c).ConfigureAwait(false);
        }

        public static async Task<RouteResult> GetRouteAsync(string fromAddress, string toAddress)
        {
            var from = (await WorldGeocoder.GeocodeAsync(fromAddress).ConfigureAwait(false)).First();
            var to = (await WorldGeocoder.GeocodeAsync(toAddress).ConfigureAwait(false)).First();
            return await GetRouteAsync(from, to).ConfigureAwait(false);
        }

        public static Task<RouteResult> GetRouteAsync(MapPoint from, MapPoint to) => GetRouteAsync(new MapPoint[] { from, to });

        public static Task<RouteResult> GetRouteAsync(GeocodeResult from, GeocodeResult to) => GetRouteAsync(from.RouteLocation, to.RouteLocation);

        public static async Task<RouteResult> GetRouteAsync(params MapPoint[] stops)
        {
            if (stops.Length < 2)
                throw new ArgumentException("At least two stops must be provided");
            if (!IsInitialized || _routeTask == null)
                throw new InvalidOperationException("Route service must first be initialized");
            var parameters = await _routeTask.CreateDefaultParametersAsync().ConfigureAwait(false);
            parameters.SetStops(stops.Select(s => new Stop(s)));
            return await _routeTask.SolveRouteAsync(parameters).ConfigureAwait(false);
        }
    }
}
