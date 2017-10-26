using System;
using System.IO;
using Xunit;
using Harlow;

namespace HarlowUnitTests
{
    public class LineTest
    {
        string lineFile = Path.Combine("Shapefiles", "Line", "tl_2014_06075_roads.shp");

        [Fact]
        public void Tiger_CA_SanFran_Roads()
        {
            ShapeFileReader reader = new ShapeFileReader(lineFile);
            reader.LoadFile();

            string json = reader.FeaturesAsJson();
            File.WriteAllText("line.json", reader.FeatureAsJson(42));

            Assert.Equal(4589, reader.Features.Length);

            Assert.Equal(283, reader.FeatureAsJson(0).Length);
            Assert.Equal(649, reader.FeatureAsJson(4588).Length);

            VectorShape[] features = reader.Features as VectorShape[];

            Assert.Equal(-122.480706, features[0].Coordinates[0][0].Value[0]);
            Assert.Equal(37.792316, features[0].Coordinates[0][0].Value[1]);
            Assert.Equal(-122.469023, features[42].Coordinates[0][0].Value[0]);
            Assert.Equal(37.737949, features[42].Coordinates[0][0].Value[1]);
            Assert.Equal(-122.364304, features[4588].Coordinates[0][0].Value[0]);
            Assert.Equal(37.819468, features[4588].Coordinates[0][0].Value[1]);

            Assert.Equal(4, reader.Features[0].Properties.Count);

            Assert.Equal("110498938555", reader.Features[0].Properties["linearid"]);
            Assert.Equal("n van horn ln", reader.Features[0].Properties["fullname"]);
            Assert.Equal("m", reader.Features[0].Properties["rttyp"]);
            Assert.Equal("s1400", reader.Features[0].Properties["mtfcc"]);

            Assert.Equal("110498935016", reader.Features[42].Properties["linearid"]);
            Assert.Equal("w portal ave", reader.Features[42].Properties["fullname"]);
            Assert.Equal("m", reader.Features[42].Properties["rttyp"]);
            Assert.Equal("s1400", reader.Features[42].Properties["mtfcc"]);

            Assert.Equal("110498933806", reader.Features[4588].Properties["linearid"]);
            Assert.Equal("avenue n", reader.Features[4588].Properties["fullname"]);
            Assert.Equal("m", reader.Features[4588].Properties["rttyp"]);
            Assert.Equal("s1400", reader.Features[4588].Properties["mtfcc"]);

        }
    }
}
