using System;
using ToStringSourceGeneratorTypes;
using Xunit;

namespace ToStringSourceGenerator.Tests
{
    public class ToStringTests
    {
        [Fact]
        public void ToString_ISOverriden()
        {
            var demoValue = new DemoTypeWithAutoToString()
            {
                Id = 1,
                Text = "Some text",
                Password = "********",
                Time = DateTime.Now.Date.Add(TimeSpan.Parse("12:34:56"))
            };


            Assert.Equal("Id: 1, Text: \"Some text\", Time: \"12:34\"", demoValue.ToString());
        }

        [Fact]
        public void ToString_IsOverriden_NestedObjects()
        {
            var demoValue = new NestedObjectToString()
            {
                Id = 1,
                Text = "Some text",
                Prop = new DemoTypeWithAutoToString()
                {
                    Id = 1,
                    Text = "Some text",
                    Password = "********",
                    Time = DateTime.Now.Date.Add(TimeSpan.Parse("12:34:56"))
                }
            };


            Assert.Equal("Id: 1, Text: \"Some text\", Prop: { Id: 1, Text: \"Some text\", Time: \"12:34\" }", demoValue.ToString());
        }
    }
}
