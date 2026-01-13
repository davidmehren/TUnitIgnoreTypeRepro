namespace TUnitIgnoreTypeRepro;

public class Tests
{
    public record Thing(string Name, int[] Numbers);
  
    [Test]
    public async Task Fails()
    {
        var foo = new Thing("Foo", [1,2,3]);
        var bar = new Thing("Foo", [1,2,3]);
        
        await Assert.That(foo).IsEquivalentTo(bar);
        await Assert.That((foo, bar)).IsEquivalentTo((bar, foo));
    }
}
