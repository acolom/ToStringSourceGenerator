using System;
using ToStringSourceGenerator.Attributes;

namespace ToStringSourceGeneratorTypes
{
    [AutoToString]
    public partial class DemoType
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [SkipToString]
        public string Password { get; set; }

        [FormatToString("HH:mm")]
        public DateTime Time { get; set; }

        
        private string PrivateValue { get; set; }
    }

  

    //[AutoToString]
    //public partial class DemoTypeWithNoProperties
    //{
    //}
}




