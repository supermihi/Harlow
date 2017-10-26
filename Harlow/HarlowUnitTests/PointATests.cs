using System.Collections.Generic;
using Xunit;
using Moq;
using Harlow;

namespace HarlowUnitTests {

	public class PointATests {

		[Fact]
		public void PointA_DefaultConstructorTest() {
			var p = new PointA();

			Assert.IsType<List<double>>(p.Value);
			Assert.Equal(2, p.Value.Count);
			Assert.Equal(0.0, p.Value[0]);
			Assert.Equal(0.0, p.Value[1]);
		}

		[Fact]
		public void PointA_XandYConstructorTest() {
		
			var p = new PointA(1.85, 3.56);

			Assert.IsType<List<double>>(p.Value);
			Assert.Equal(2, p.Value.Count);
			Assert.Equal(1.85, p.Value[0]);
			Assert.Equal(3.56, p.Value[1]);
		}

		[Fact]
		public void PointA_GetEnumeratorTest() {
			var p = new PointA(123.456, 789.012);
			
			Assert.IsAssignableFrom<IEnumerator<double>>(p.GetEnumerator());
			
			IEnumerator<double> pe = p.GetEnumerator();
			pe.MoveNext();
			Assert.Equal(123.456, pe.Current);
			pe.MoveNext();
			Assert.Equal(789.012, pe.Current);

		}
	}
}
