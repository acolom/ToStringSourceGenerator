
# ToString() Source Generator

This sourcer generator allows to auto generate ToString() methods. It's usefull to log POCO objects. Feel free to comment or suggest changes

## How to use

Now some changes need to be applied to csproj in order to execute the generator

```XML
<ItemGroup>
    <ProjectReference Include="..\ToStringSourceGenerator\ToStringSourceGenerator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="true" />
</ItemGroup>
```

In next releases soruce generator will be installed from NUGET

After installing simply add some attrributes to your class.

## Example

Add `[AutoToString]` attribute to your class and make it partial.

With `[SkipToString]` avoid property output and with `[FormatToString]` customize property output

```C#
[AutoToString]
public partial class DemoTypeWithAutoToString
{
    public int Id { get; set; }
    public string Text { get; set; }

    [SkipToString]
    public string Password { get; set; }

    [FormatToString("HH:mm")]
    public DateTime Time { get; set; }

    private string PrivateValue { get; set; }
}
```

Generator will override `ToString()` method and will create a method like this one:

```C#
public override string ToString()
{
    return $"Id: {Id}, Text: \"{Text}\", Time: \"{Time:HH:mm}\"";
}
```

Nested objectes are also supported (if AutoToString attribute is added to nested classes).

## Under development

As source generator is in preview, this project is not ended.

## Next Changes

Next changes planned are:

* Detect properties that implements IEnumerable interface to output it's content
* Create Nuget package
