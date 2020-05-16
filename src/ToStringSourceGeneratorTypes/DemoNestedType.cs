using ToStringSourceGenerator.Attributes;

namespace ToStringSourceGeneratorTypes
{
    [AutoToString]
    public partial class DemoNestedType
    {
        public DemoNestedType()
        {
            Prop = new DemoType();
        }
        public int Id { get; set; }
        public string? Text { get; set; }
        public DemoType Prop { get; set; }

    }
}
