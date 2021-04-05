using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RocketLandingLibraryTest
{
    [TestClass]
    public class LandingTest
    {
        [TestMethod]
        public void CheckPosition_ShouldReturnedOk()
        {
            var x = 14;
            var y = 14;
            var expectedResult = RocketLandingLibrary.Landing.LandingState.OkForLanding;

            var result = RocketLandingLibrary.Landing.CheckPosition(x, y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CheckPosition_ShouldReturnedClash()
        {
            var x1 = 5;
            var y1 = 5;
            var x2 = 6;
            var y2 = 6;
            var expectedResult = RocketLandingLibrary.Landing.LandingState.Clash;

            RocketLandingLibrary.Landing.CheckPosition(x1, y1);
            var result = RocketLandingLibrary.Landing.CheckPosition(x2, y2);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CheckPosition_ShouldReturnedOut()
        {
            var x = 16;
            var y = 16;
            var expectedResult = RocketLandingLibrary.Landing.LandingState.OutOfPlatform;

            var result = RocketLandingLibrary.Landing.CheckPosition(x, y);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
