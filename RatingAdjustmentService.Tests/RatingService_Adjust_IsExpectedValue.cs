using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatingAdjustment.Services;

namespace RatingAdjustment.UnitTests.Services
{
    [TestClass]
    public class RatingService_Adjust_IsExpectedValue
    {
        private readonly RatingAdjustmentService _ratingAdjustmentService;

        public RatingService_Adjust_IsExpectedValue()
        {
            _ratingAdjustmentService = new RatingAdjustmentService();
        }

        [DataTestMethod]
        [DataRow(4.41, 483, 4.250850)]
        public void IsExpectedValue(double stars, double ratings, double expected_value)
        {
            Assert.AreEqual(expected_value, _ratingAdjustmentService.Adjust(stars, ratings), 0.000001);
        }
    }
}
