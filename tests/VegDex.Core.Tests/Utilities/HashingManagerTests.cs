using VegDex.Core.Utilities;

namespace VegDex.Core.Tests.Utilities;

[TestClass]
public class HashingManagerTests
{
    [TestInitialize]
    public void Init()
    {
        _hashingManager = new HashingManager();
    }
    private HashingManager _hashingManager;
    [TestMethod]
    public void Hash_Success()
    {
        // Arrange
        const string toHash = "hunter2";

        // Act
        byte[] hash = _hashingManager.Hash(toHash);

        // Assert
        Assert.IsNotNull(hash);
    }
    [TestMethod]
    public void HashToString_Success()
    {
        // Arrange
        const string toHash = "hunter2";

        // Act
        string result = _hashingManager.HashToString(toHash);

        // Assert
        Assert.IsNotNull(result);
    }
    [TestMethod]
    public void Verify_ReturnFalse_Success()
    {
        // Act
        byte[] hash = _hashingManager.Hash("password1234");
        bool result = _hashingManager.Verify("password", hash);

        // Assert
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void Verify_ReturnTrue_Success()
    {
        // Arrange
        const string toHash = "hunter2";

        // Act
        byte[] hash = _hashingManager.Hash(toHash);
        bool result = _hashingManager.Verify(toHash, hash);

        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void VerifyString_ReturnFalse_Success()
    {
        // Act
        string hash = _hashingManager.HashToString("hunter2");
        bool result = _hashingManager.Verify("hunter3", hash);

        // Assert
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void VerifyString_ReturnTrue_Success()
    {
        // Arrange
        const string toHash = "hunter2";

        // Act
        string hash = _hashingManager.HashToString(toHash);
        bool result = _hashingManager.Verify(toHash, hash);

        // Assert
        Assert.IsTrue(result);
    }
}
