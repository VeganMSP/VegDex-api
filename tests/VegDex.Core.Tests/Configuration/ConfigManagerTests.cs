using VegDex.Core.Configuration;
using VegDex.TestHelpers;

namespace VegDex.Core.Tests.Configuration;

[TestClass]
public class ConfigManagerTests
{
    [TestMethod]
    public void ConfigManager_HasProperties()
    {
        var obj = new ConfigManager();

        // Assert
        Assert.AreEqual(1, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("App"));
    }
}
