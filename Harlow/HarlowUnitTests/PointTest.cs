using System;
using System.IO;
using Xunit;
using Harlow;

namespace HarlowUnitTests
{
    public class PointTest
    {
        string pointFile = Path.Combine("Shapefiles", "Point", "builtupp_usa.shp");
        
        [Fact]
        public void USGS_CitiesAndTowns()
        {
            ShapeFileReader reader = new ShapeFileReader(pointFile);
            reader.LoadFile();

            string json = reader.FeaturesAsJson();
            File.WriteAllText("point.json", reader.FeatureAsJson(42));

            Assert.Equal(38187, reader.Features.Length);

            Assert.Equal(157, reader.FeatureAsJson(0).Length);
            Assert.Equal(159, reader.FeatureAsJson(38186).Length);

            VectorPoint[] features = reader.Features as VectorPoint[];

            Assert.Equal(-100.06096779999996, features[0].Coordinates[0]);
            Assert.Equal(48.813056899065479, features[0].Coordinates[1]);
            Assert.Equal(-101.22071379999994, features[42].Coordinates[0]);
            Assert.Equal(48.513074399064209, features[42].Coordinates[1]);
            Assert.Equal(-149.22967529296875, features[38186].Coordinates[0]);
            Assert.Equal(61.541870116397909, features[38186].Coordinates[1]);

            Assert.Equal(5, reader.Features[0].Properties.Count);
            
            Assert.Equal("dunseith", reader.Features[0].Properties["nam"]);
            Assert.Equal("al020", reader.Features[0].Properties["f_code"]);
            Assert.Equal("773", reader.Features[0].Properties["pop"]);
            Assert.Equal("2010", reader.Features[0].Properties["ypc"]);
            Assert.Equal("usa", reader.Features[0].Properties["soc"]);

            Assert.Equal(5, reader.Features[42].Properties.Count);
            Assert.Equal("glenburn", reader.Features[42].Properties["nam"]);
            Assert.Equal("al020", reader.Features[42].Properties["f_code"]);
            Assert.Equal("380", reader.Features[42].Properties["pop"]);
            Assert.Equal("2010", reader.Features[42].Properties["ypc"]);
            Assert.Equal("usa", reader.Features[42].Properties["soc"]);

            Assert.Equal(5, reader.Features[38186].Properties.Count);
            Assert.Equal("matanuska", reader.Features[38186].Properties["nam"]);
            Assert.Equal("al020", reader.Features[38186].Properties["f_code"]);
            Assert.Equal("-999", reader.Features[38186].Properties["pop"]);
            Assert.Equal("2010", reader.Features[38186].Properties["ypc"]);
            Assert.Equal("usa", reader.Features[38186].Properties["soc"]);
        }
    }
}
