using System;
using ToStringSourceGeneratorTypes;
using Xunit;

namespace ToStringSourceGenerator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("I am autogenerated", new DemoTypeWithAutoToString().ToString());
        }
    }
}
