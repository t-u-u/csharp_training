using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData accData = new AccountData("admin", "secret");
            app.Auth
                .Logout()
                .Login(accData);
            Assert.IsTrue(app.Auth.IsLoggedIn(accData));
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            AccountData accData = new AccountData("admin", "secret1");
            app.Auth
                .Logout()
                .Login(accData);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
