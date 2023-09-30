using VegDex.Core.Utilities;

namespace VegDex.Core.Tests.Utilities;

[TestClass]
public class HashingManagerTests
{
    private HashingManager _hashingManager;
    [TestInitialize]
    public void Init()
    {
        _hashingManager = new HashingManager();
    }
    [TestMethod]
    public void Hash_Success()
    {
        // Arrange
        const string toHash = "hunter2";
        
        // Act
        var hash = _hashingManager.Hash(toHash);
        
        // Assert
        Assert.IsNotNull(hash);
    }
    [TestMethod]
    public void HashToString_Success()
    {
        // Arrange
        const string toHash = "hunter2";

        // Act
        var result = _hashingManager.HashToString(toHash);

        // Assert
        Assert.IsNotNull(result);
    }
    [TestMethod]
    public void VerifyString_ReturnTrue_Success()
    {
        // Arrange
        const string toHash = "hunter2";

        // Act
        var hash = _hashingManager.HashToString(toHash);
        var result = _hashingManager.Verify(toHash, hash);

        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void VerifyString_ReturnFalse_Success()
    {
        // Act
        var hash = _hashingManager.HashToString("hunter2");
        var result = _hashingManager.Verify("hunter3", hash);

        // Assert
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void Verify_ReturnTrue_Success()
    {
        // Arrange
        const string toHash = "hunter2";
        
        // Act
        var hash = _hashingManager.Hash(toHash);
        var result = _hashingManager.Verify(toHash, hash);
        
        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void Verify_ReturnFalse_Success()
    {
        // Act
        var hash = _hashingManager.Hash("password1234");
        var result = _hashingManager.Verify("password", hash);

        // Assert
        Assert.IsFalse(result);
    }
}
