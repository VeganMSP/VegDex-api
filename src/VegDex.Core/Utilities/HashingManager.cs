// https://codereview.stackexchange.com/questions/176697/net-core-mvc-future-proof-hashing-of-passwords

using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace VegDex.Core.Utilities;

/// <summary>
/// Provides methods Hashing and Verification of clear tests
/// </summary>
public class HashingManager
{
    /// <summary>
    /// The default number of Iterations
    /// </summary>
    private const int DefaultIterations = 10000;
    /// <summary>
    /// Holds all possible Hash Versions
    /// </summary>
    private readonly Dictionary<short, HashVersion> _versions = new()
    {
        {
            1, new HashVersion
            {
                Version = 1,
                KeyDerivation = KeyDerivationPrf.HMACSHA512,
                HashSize = 256 / 8,
                SaltSize = 128 / 8
            }
        }
    };
    /// <summary>
    /// The default Hash Version, which should be used, if a new Hash is created
    /// </summary>
    private HashVersion DefaultVersion => _versions[1];
    /// <summary>
    /// Gets a random byte array
    /// </summary>
    /// <param name="length">The lenght of the byte array</param>
    /// <returns>The random byte array</returns>
    public byte[] GetRandomBytes(int length)
    {
        var data = new byte[length];
        using (var randomNumberGenerator = RandomNumberGenerator.Create())
        {
            randomNumberGenerator.GetBytes(data);
        }
        return data;
    }
    /// <summary>
    /// Creates a Hash of a clear text
    /// </summary>
    /// <param name="clearText">The clear text</param>
    /// <param name="iterations">The number of iterations the hash algorithm should run</param>
    /// <returns>The Hash</returns>
    public byte[] Hash(string clearText, int iterations = DefaultIterations)
    {
        var currentVersion = DefaultVersion;

        // get the byte arrays of the hash and meta information
        byte[] saltBytes = GetRandomBytes(currentVersion.SaltSize);
        byte[] versionBytes = BitConverter.GetBytes(currentVersion.Version);
        byte[] iterationBytes = BitConverter.GetBytes(iterations);
        byte[] hashBytes = KeyDerivation.Pbkdf2(clearText, saltBytes, currentVersion.KeyDerivation, iterations,
            currentVersion.HashSize);

        // calculate the indexes for the combined hash
        var indexVersion = 0;
        int indexIteration = indexVersion + 2;
        int indexSalt = indexIteration + 4;
        int indexHash = indexSalt + currentVersion.SaltSize;

        // combine all data to one result hash
        var resultBytes = new byte[2 + 4 + currentVersion.SaltSize + currentVersion.HashSize];
        Array.Copy(versionBytes, 0, resultBytes, indexVersion, 2);
        Array.Copy(iterationBytes, 0, resultBytes, indexIteration, 4);
        Array.Copy(saltBytes, 0, resultBytes, indexSalt, currentVersion.SaltSize);
        Array.Copy(hashBytes, 0, resultBytes, indexHash, currentVersion.HashSize);
        return resultBytes;
    }
    /// <summary>
    /// Creates a Hash of a clear test and converts it to a Base64 string representation
    /// </summary>
    /// <param name="clearText">The clear text</param>
    /// <param name="iterations">The number of iterations the hash algorithm should run</param>
    /// <returns>The Hash</returns>
    public string HashToString(string clearText, int iterations = DefaultIterations)
    {
        byte[] data = Hash(clearText, iterations);
        return Convert.ToBase64String(data);
    }
    /// <summary>
    /// Checks if a given Hash uses the latest Hash Version
    /// </summary>
    /// <param name="data">The Hash</param>
    /// <returns>True if the Hash is the latest Version, otherwise False.</returns>
    public bool IsLatestHashVersion(byte[] data)
    {
        var version = BitConverter.ToInt16(data, 0);
        return version == DefaultVersion.Version;
    }
    /// <summary>
    /// Checks if a given Hash uses the latest Hash Version
    /// </summary>
    /// <param name="data">The hash</param>
    /// <returns>True if the Hash is the latest Version, otherwise False.</returns>
    public bool IsLatestHashVersion(string data)
    {
        byte[] dataBytes = Convert.FromBase64String(data);
        return IsLatestHashVersion(dataBytes);
    }
    /// <summary>
    /// Verifies a given clear text against a hash
    /// </summary>
    /// <param name="clearText">The clear text</param>
    /// <param name="data">The hash</param>
    /// <returns>True if the Hashes are equal, otherwise False.</returns>
    public bool Verify(string clearText, byte[] data)
    {
        var currentVersion = _versions[BitConverter.ToInt16(data, 0)];
        var iteration = BitConverter.ToInt32(data, 2);

        // Create the byte arrays for the salt and hash
        var saltBytes = new byte[currentVersion.SaltSize];
        var hashBytes = new byte[currentVersion.HashSize];

        // Calculate the indexes of the salt and the hash
        int indexSalt = 2 + 4;
        int indexHash = indexSalt + currentVersion.SaltSize;

        // Fill the byte arrays with salt and hash
        Array.Copy(data, indexSalt, saltBytes, 0, currentVersion.SaltSize);
        Array.Copy(data, indexHash, hashBytes, 0, currentVersion.HashSize);

        // Hash the current clearText with the parameters given via the data
        byte[] verificationHashBytes = KeyDerivation.Pbkdf2(clearText, saltBytes, currentVersion.KeyDerivation,
            iteration,
            currentVersion.HashSize);

        // Check if the generated hashes are equal
        return hashBytes.SequenceEqual(verificationHashBytes);
    }
    /// <summary>
    /// Verifies a given clear text against a hash
    /// </summary>
    /// <param name="clearText">The clear text</param>
    /// <param name="data">The hash</param>
    /// <returns>True if the Hashes are equal, otherwise False.</returns>
    public bool Verify(string clearText, string data)
    {
        byte[] dataBytes = Convert.FromBase64String(data);
        return Verify(clearText, dataBytes);
    }
    /// <summary>
    /// Provides information about a specific Hash Version
    /// </summary>
    private class HashVersion
    {
        public int HashSize { get; set; }
        public KeyDerivationPrf KeyDerivation { get; set; }
        public int SaltSize { get; set; }
        public short Version { get; set; }
    }
}
