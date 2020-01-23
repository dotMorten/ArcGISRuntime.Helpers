using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class WorldGeocoder
    {
        private static LocatorTask _geocoder;

        static WorldGeocoder()
        {
            _geocoder = new LocatorTask(new Uri(ArcGISOnlineServices.WorldGeocodeServiceUri));
        }

        public static async Task<IReadOnlyList<SuggestResult>> SuggestAsync(string searchText, Geometry.Geometry? searchArea = null, int maxResults = 10)
        {
            await _geocoder.LoadAsync().ConfigureAwait(false);
            SuggestParameters suggestParams = new SuggestParameters { MaxResults = maxResults, SearchArea = searchArea };
            return await _geocoder.SuggestAsync(searchText, suggestParams).ConfigureAwait(false);
        }

        public static async Task<IReadOnlyList<GeocodeResult>> GeocodeAsync(string searchText, Geometry.Geometry? searchArea = null, int maxResults = 10)
        {
            await _geocoder.LoadAsync().ConfigureAwait(false);
            var parameters = new GeocodeParameters() { MaxResults = maxResults, SearchArea = searchArea };
            return await _geocoder.GeocodeAsync(searchText, parameters).ConfigureAwait(false);
        }

        public static async Task<IReadOnlyList<GeocodeResult>> ReverseGeocodeAsync(MapPoint location, double maxDistance = 200)
        {
            await _geocoder.LoadAsync().ConfigureAwait(false);
            var parameters = new ReverseGeocodeParameters() { MaxDistance = maxDistance };
            return await _geocoder.ReverseGeocodeAsync(location, parameters).ConfigureAwait(false);
        }
    }
}
