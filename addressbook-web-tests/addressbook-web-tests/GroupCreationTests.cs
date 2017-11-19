using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupsPage();
            InitGroupCreation();
            FillNewGroupForm(new GroupData("111", "222" , "333"));
            SubmitGroupCreation();
            OpenGroupsPage();
            Logout();
        }

        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupsPage();
            SelectGroup(1);
            DeleteGroups();
            OpenGroupsPage();
            Logout();
        }
    }
}
