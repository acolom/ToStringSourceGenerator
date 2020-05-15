using System;
using ToStringSourceGeneratorTypes;
using Xunit;

namespace ToStringSourceGenerator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ToString_ISOverriden()
        {
            var demoValue = new DemoTypeWithAutoToString()
            {
                Id = 1,
                Text = "Some text"
            };

            Assert.Equal("Id: 1, Text: \"Some text\"", demoValue.ToString());
        }
    }
}
