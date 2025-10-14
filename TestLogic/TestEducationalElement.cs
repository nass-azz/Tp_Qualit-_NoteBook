using System;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestEducationalElement
    {
        [Fact]
        public void Name_MustNotBeEmpty()
        {
            var u = new Unit();
            Assert.Throws<ArgumentException>(() => u.Name = "");
            Assert.Throws<ArgumentException>(() => u.Name = "  ");
        }

        [Fact]
        public void Coef_MustBePositive()
        {
            var u = new Unit();
            Assert.Throws<ArgumentException>(() => u.Coef = 0f);
            Assert.Throws<ArgumentException>(() => u.Coef = -1f);
        }

        [Fact]
        public void ToString_Returns_Name_And_Coef()
        {
            var u = new Unit { Name = "UE Info", Coef = 2.5f };
            string result = u.ToString();
            Assert.Contains("UE Info", result);
            Assert.Contains("2,5", result);
        }
    }
}
