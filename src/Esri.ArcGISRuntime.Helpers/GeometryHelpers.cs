using System;
using Esri.ArcGISRuntime.Geometry;

namespace Esri.ArcGISRuntime.Helpers
{
    public static class GeometryHelpers
    {
        public static MapPoint FromLatLong(double latitude, double longitude, double? elevation = null, double? measure = null)
        {

            if (!measure.HasValue)
            {
                if (!elevation.HasValue)
                    return new MapPoint(longitude, latitude, SpatialReferences.Wgs84);
                else
                    return new MapPoint(longitude, latitude, elevation.Value, SpatialReferences.Wgs84);
            }
            if (!elevation.HasValue)
                return MapPoint.CreateWithM(longitude, latitude, measure.Value, SpatialReferences.Wgs84);
            else
                return MapPoint.CreateWithM(longitude, latitude, elevation.Value, measure.Value, SpatialReferences.Wgs84);

        }

        public static MapPoint FromLatLong(this double[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length < 2)
                throw new ArgumentException("At least two values required");
            return FromLatLong(latitude: values[0], 
                               longitude: values[1], 
                               elevation: values.Length == 3 ? values[2] : (double.IsNaN(values[2]) ? null : (double?)values[2]), 
                               measure: values.Length > 3 ? (double?)values[3] : null);
        }

        public static double[] ToLatLong(this MapPoint mp)
        {
            MapPoint? p;
            if (mp.SpatialReference.Wkid == 4326)
            {
                p = mp;
            }
            else
            {
                p = GeometryEngine.Project(mp, SpatialReferences.Wgs84) as MapPoint;
            }
            if (p == null)
                return new double[] { };
            double[] result = new double[2 + (mp.HasZ || mp.HasM ? 1 : 0) + (mp.HasM ? 1 : 0)];
            result[0] = p.Y;
            result[1] = p.X;
            if (mp.HasZ)
                result[2] = mp.Z;
            if (mp.HasM)
            {
                if (!mp.HasZ)
                    result[2] = double.NaN;
                result[3] = mp.M;
            }
            return result;
        }
    }
}
