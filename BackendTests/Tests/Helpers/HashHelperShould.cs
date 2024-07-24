using Backend.Helpers;

namespace BackendTests.Tests.Helpers;

public class HashHelperShould
{
    [Fact]
    public void GetSha512HashBase64_SimpleString_ReturnsCorrectHash()
    {
        // Arrange
        string input = "hello world";

        // Act
        string base64Hash = HashHelper.ComputeSha512(input);

        // Assert
        Assert.NotNull(base64Hash);
        Assert.Equal("309ecc489c12d6eb4cc40f50c902f2b4d0ed77ee511a7c7a9bcd3ca86d4cd86f989dd35bc5ff499670da34255b45b0cfd830e81f605dcf7dc5542e93ae9cd76f", base64Hash);
    }

    [Fact]
    public void GetSha512HashBase64_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => HashHelper.ComputeSha512(input));
    }
}