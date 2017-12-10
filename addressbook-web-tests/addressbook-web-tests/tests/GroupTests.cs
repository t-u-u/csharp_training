using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups
                .CreateGroup(new GroupData("111", "222" , "333"));
            app.Navigator.OpenGroupsPage();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups
                .CreateGroup(new GroupData("", "", ""));
            app.Navigator.OpenGroupsPage();
        }

        [Test]
        public void GroupUpdateTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups
                .SelectGroup(1)
                .EditGroups()
                .FillGroupForm(new GroupData("111 mod", "222 mod", "333 mod"))
                .SubmitGroupUpdate();
            app.Navigator.OpenGroupsPage();
        }

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups
                .SelectGroup(1)
                .DeleteGroups();
            app.Navigator.OpenGroupsPage();
        }
    }
}
