namespace TUnitIgnoreTypeRepro;

public class Tests
{
    public record IgnoreMe(string Message);
    
    public record TypeOne(IgnoreMe IgnoreOne, IgnoreMe IgnoreTwo);
    public record TypeTwo((IgnoreMe, IgnoreMe) Ignores);
    
    [Test]
    public async Task Works()
    {
        var actual = new TypeOne(new IgnoreMe("foobar"), new IgnoreMe("foobar"));
        var expected = new TypeOne(new IgnoreMe("baz"), new IgnoreMe("baz"));
        
        await Assert.That(actual).IsEquivalentTo(expected).IgnoringType<IgnoreMe>();
    }
    [Test]
    public async Task Fails()
    {
        var actual = new TypeTwo((new IgnoreMe("foobar"), new IgnoreMe("foobar")));
        var expected = new TypeTwo((new IgnoreMe("baz"), new IgnoreMe("baz")));
        
        await Assert.That(actual).IsEquivalentTo(expected).IgnoringType<IgnoreMe>();
    }
}
