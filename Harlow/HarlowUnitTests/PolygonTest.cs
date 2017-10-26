using System;
using System.IO;
using Xunit;
using Harlow;

namespace HarlowUnitTests
{
    public class PolygonTest
    {
        string polyFile = Path.Combine("Shapefiles", "Polygon", "tl_2014_06_place.shp");

        [Fact]
        public void Tiger_US_PlaceBoundaries()
        {
            ShapeFileReader reader = new ShapeFileReader(polyFile);
            reader.LoadFile();

            string json = reader.FeaturesAsJson();
            File.WriteAllText("polygon.json", reader.FeatureAsJson(42));

            Assert.Equal(1516, reader.Features.Length);

            Assert.Equal(4780, reader.FeatureAsJson(0).Length);
            Assert.Equal(13137, reader.FeatureAsJson(1515).Length);

            VectorShape[] features = reader.Features as VectorShape[];

            Assert.Equal(-118.456008, features[0].Coordinates[0][0].Value[0]);
            Assert.Equal(34.284903, features[0].Coordinates[0][0].Value[1]);
            Assert.Equal(-118.30807, features[42].Coordinates[0][0].Value[0]);
            Assert.Equal(34.161224, features[42].Coordinates[0][0].Value[1]);
            Assert.Equal(-122.060783, features[1515].Coordinates[0][0].Value[0]);
            Assert.Equal(37.05574, features[1515].Coordinates[0][0].Value[1]);

            Assert.Equal(16, reader.Features[0].Properties.Count);

            Assert.Equal("06", reader.Features[42].Properties["statefp"]);
            Assert.Equal("30000", reader.Features[42].Properties["placefp"]);
            Assert.Equal("02410597", reader.Features[42].Properties["placens"]);
            Assert.Equal("0630000", reader.Features[42].Properties["geoid"]);
            Assert.Equal("glendale", reader.Features[42].Properties["name"]);
            Assert.Equal("glendale city", reader.Features[42].Properties["namelsad"]);
            Assert.Equal("25", reader.Features[42].Properties["lsad"]);
            Assert.Equal("c1", reader.Features[42].Properties["classfp"]);
            Assert.Equal("y", reader.Features[42].Properties["pcicbsa"]);
            Assert.Equal("n", reader.Features[42].Properties["pcinecta"]);
            Assert.Equal("g4110", reader.Features[42].Properties["mtfcc"]);
            Assert.Equal("a", reader.Features[42].Properties["funcstat"]);
            Assert.Equal("78848571", reader.Features[42].Properties["aland"]);
            Assert.Equal("337673", reader.Features[42].Properties["awater"]);
            Assert.Equal("+34.1813929", reader.Features[42].Properties["intptlat"]);
            Assert.Equal("-118.2458301", reader.Features[42].Properties["intptlon"]);
        }
    }
}
