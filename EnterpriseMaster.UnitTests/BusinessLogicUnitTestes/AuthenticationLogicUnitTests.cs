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
        public async Task EmailAlreadyExist_EmailExists_ReturnsTrue()
        {
            // Arrange
            var user = new Users
            {
                Email = "user@example.com",
                Password = "hashed_password" // Replace with the actual hashed password
            };

            var usersList = new List<Users>
            {
                new Users
                {
                    Email = "user@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("hashed_password") // Replace with the actual hashed password
                },
            // Add more user data for testing
            };

            // Act
            bool result = await authenticationLogic.EmailAlreadyExist(user.Email, usersList);

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

        [Test]
        public async Task AuthenticateAsync_ValidUser_ReturnsTrue()
        {
            // Arrange
            var user = new Users
            {
                Email = "user@example.com",
                Password = "hashed_password" // Replace with the actual hashed password
            };

            var usersList = new List<Users>
            {
                new Users
                {
                    Email = "user@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("hashed_password") // Replace with the actual hashed password
                },
            // Add more user data for testing
            };

            // Act
            var result = await authenticationLogic.AuthenticateAsync(user, usersList);

            // Assert
            Assert.IsTrue(result, "Expected authentication to be successful.");
        }

        [Test]
        public async Task AuthenticateAsync_InvalidUser_ReturnsFalse()
        {
            // Arrange
            var user = new Users
            {
                Email = "user@example.com",
                Password = "incorrect_password"
            };

            var usersList = new List<Users>
            {
                new Users
                {
                    Email = "user@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("hashed_password")
                }
            };

            // Act
            var result = await authenticationLogic.AuthenticateAsync(user, usersList);

            // Assert
            Assert.IsFalse(result, "Expected authentication to be unsuccessful.");
        }

        #endregion
    }
}
