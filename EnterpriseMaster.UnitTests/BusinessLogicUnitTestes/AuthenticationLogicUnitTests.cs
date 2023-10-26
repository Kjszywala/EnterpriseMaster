using EnterpriseMaster.BusinessLogic.AuthenticationLogic;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.UnitTests.BusinessLogicUnitTestes
{
    [TestFixture]
    public class AuthenticationLogicUnitTests
    {
        #region SetUp

        AuthenticationLogic authenticationLogic = new AuthenticationLogic();

        #endregion

        #region Tests

        [Test]
        public void IsPasswordRegexValid_ValidPassword_ReturnsTrue()
        {
            // Act
            bool result = authenticationLogic.IsPasswordRegexValid("ValidPassword1");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPasswordRegexValid_InvalidPassword_ReturnsFalse()
        {
            // Act
            bool result = authenticationLogic.IsPasswordRegexValid("invalid");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsPasswordValidAsync_ValidPassword_ReturnsTrue()
        {
            // Arrange
            string storedPassword = BCrypt.Net.BCrypt.HashPassword("ValidPassword1");

            // Act
            bool result = await authenticationLogic.IsPasswordValidAsync("ValidPassword1", storedPassword);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsPasswordValidAsync_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string storedPassword = BCrypt.Net.BCrypt.HashPassword("ValidPassword1");

            // Act
            bool result = await authenticationLogic.IsPasswordValidAsync("InvalidPassword", storedPassword);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AuthenticateAsync_EmailExists_ReturnsTrue()
        {
            // Arrange
            var user = new Users { Email = "existing@example.com" };
            var usersList = new List<Users> { new Users { Email = "existing@example.com" } };

            // Act
            bool result = await authenticationLogic.AuthenticateAsync(user, usersList);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task AuthenticateAsync_EmailDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var user = new Users { Email = "new@example.com" };
            var usersList = new List<Users> { new Users { Email = "existing@example.com" } };

            // Act
            bool result = await authenticationLogic.AuthenticateAsync(user, usersList);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task EmailAlreadyExist_EmailExists_ReturnsTrue()
        {
            // Arrange
            var email = "existing@example.com";
            var usersList = new List<Users> { new Users { Email = "existing@example.com" } };

            // Act
            bool result = await authenticationLogic.EmailAlreadyExist(email, usersList);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task EmailAlreadyExist_EmailDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var email = "new@example.com";
            var usersList = new List<Users> { new Users { Email = "existing@example.com" } };

            // Act
            bool result = await authenticationLogic.EmailAlreadyExist(email, usersList);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEmailValidAsync_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var email = "valid@example.com";

            // Act
            bool result = authenticationLogic.IsEmailValidAsync(email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmailValidAsync_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            var email = "invalid-email";

            // Act
            bool result = authenticationLogic.IsEmailValidAsync(email);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion
    }
}
