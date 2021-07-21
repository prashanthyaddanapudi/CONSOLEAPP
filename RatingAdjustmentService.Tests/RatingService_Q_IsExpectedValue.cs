using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatingAdjustment.Services;
using System.Reflection;

namespace RatingAdjustment.UnitTests.Services
{
    [TestClass]
    public class RatingService_Q_IsExpectedValue
    {
        private readonly RatingAdjustmentService _ratingAdjustmentService;

        public RatingService_Q_IsExpectedValue()
        {
            _ratingAdjustmentService = new RatingAdjustmentService();
        }

        [DataTestMethod]
        [DataRow(4.6, 486.0, 0.024442)]
        public void IsExpectedValue(double stars, double ratings, double expected_value)
        {
            var methodInfo = _ratingAdjustmentService.GetType().GetMethod("SetPercentPositive", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(_ratingAdjustmentService, new object[] { stars });

            methodInfo = _ratingAdjustmentService.GetType().GetMethod("SetQ", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(_ratingAdjustmentService, new object[] { ratings });

            var varInfo = _ratingAdjustmentService.GetType().GetField("_q", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(expected_value, (double)varInfo.GetValue(_ratingAdjustmentService), 0.000001);
        }
    }
}
