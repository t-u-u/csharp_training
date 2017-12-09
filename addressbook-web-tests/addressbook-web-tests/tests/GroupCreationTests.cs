using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(new GroupData("111", "222" , "333"))
                .SubmitGroupCreation();
            app.Navigator.OpenGroupsPage();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(new GroupData("", "", ""))
                .SubmitGroupCreation();
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
