using VegDex.Core.Entities.Config;
using VegDex.TestHelpers;

namespace VegDex.Core.Tests.Entities.Config;

[TestClass]
public class AppTests
{
    [TestMethod]
    public void App_HasProperties()
    {
        var obj = new App();

        // Assert
        Assert.AreEqual(1, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("SecretKey"));
    }
}
