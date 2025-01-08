using Business.Helpers;

namespace Business.Tests.Helpers;

public class UniqueIdentifierGenerator_Test
{
    [Fact]
    public void Generate_ShouldReturnStringOfTypeGuid()
    {
        //act
        string id = UniqueIdentifierGenerator.Generate();

        //assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }
}
