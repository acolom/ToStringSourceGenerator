using System;
using ToStringSourceGenerator;

namespace ToStringSourceGeneratorTypes
{
    
    [AutoToString]
    public partial class DemoTypeWithAutoToString
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    [AutoToString]
    public class DemoTypeWithInvalidAutoToString
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class DemoTypeWithOutAutoToString
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}




