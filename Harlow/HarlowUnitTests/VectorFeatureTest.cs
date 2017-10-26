using Moq;
using Harlow;
using Xunit;

namespace HarlowUnitTests {

	public class VectorFeatureTest {

		[Fact]
		public void Test_VectorFeature_Point() {
			object[] parm = new object[1];
			parm[0] = ShapeType.Point;

			var  vfMock = new Mock<VectorFeature>(parm);

			Assert.Null(vfMock.Object.Type);
			Assert.Null(vfMock.Object.Coordinates);
			Assert.Null(vfMock.Object.Bbox);
			Assert.NotNull(vfMock.Object.Properties);
			
		}

		[Fact]
		public void Test__VectorFeature_NotPoint() {
			object[] parm = new object[1];
			parm[0] = ShapeType.Polygon;

			var  vfMock = new Mock<VectorFeature>(parm);

			Assert.Null(vfMock.Object.Type);
			Assert.Null(vfMock.Object.Coordinates);
			Assert.NotNull(vfMock.Object.Bbox);
			Assert.Equal(4, vfMock.Object.Bbox.Length);
			Assert.NotNull(vfMock.Object.Properties);
			
		}
	}
}
