using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.OpenGroupsPage();
            app.Groups.InitGroupCreation();
            app.Groups.FillNewGroupForm(new GroupData("111", "222" , "333"));
            app.Groups.SubmitGroupCreation();
            app.Navigator.OpenGroupsPage();
            app.Auth.Logout();
        }

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.OpenGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.DeleteGroups();
            app.Navigator.OpenGroupsPage();
            app.Auth.Logout();
        }
    }
}
