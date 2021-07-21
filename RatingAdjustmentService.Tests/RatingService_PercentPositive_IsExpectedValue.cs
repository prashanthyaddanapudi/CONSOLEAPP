using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatingAdjustment.Services;
using System.Reflection;

namespace RatingAdjustment.UnitTests.Services
{
    [TestClass]
    public class RatingService_PercentPositive_IsExpectedValue
    {
        private readonly RatingAdjustmentService _ratingAdjustmentService;

        public RatingService_PercentPositive_IsExpectedValue()
        {
            _ratingAdjustmentService = new RatingAdjustmentService();
        }

        [DataTestMethod]
        [DataRow(0.0, 0.0)]
        [DataRow(1.0, 0.2)]
        [DataRow(2.0, 0.4)]
        [DataRow(3.0, 0.6)]
        [DataRow(4.0, 0.8)]
        [DataRow(4.5, 0.9)]
        [DataRow(5.0, 1.0)]
        public void IsExpectedValue(double stars, double expected_value)
        {
            var methodInfo = _ratingAdjustmentService.GetType().GetMethod("SetPercentPositive", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(_ratingAdjustmentService, new object[] { stars });
            var varInfo = _ratingAdjustmentService.GetType().GetField("_percent_positive", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(varInfo.GetValue(_ratingAdjustmentService), expected_value);
        }
    }
}
