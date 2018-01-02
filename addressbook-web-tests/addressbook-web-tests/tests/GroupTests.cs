using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
                .CreateGroup(new GroupData("111", "222" , "333"));
            app.Navigator.OpenGroupsPage();

            List<GroupData> groups = app.Groups.GetGroupList();
            oldGroups.Add(new GroupData("111", "222", "333"));
            oldGroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldGroups, groups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
                .CreateGroup(new GroupData("111'", "222", "333"));
            app.Navigator.OpenGroupsPage();
            
            List<GroupData> groups = app.Groups.GetGroupList();
            oldGroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldGroups, groups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            app.Navigator.OpenGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups
                .CreateGroup(new GroupData("", "", ""));
            app.Navigator.OpenGroupsPage();

            oldGroups.Add(new GroupData("", "", ""));
            List<GroupData> groups = app.Groups.GetGroupList();
            oldGroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldGroups, groups);
        }

        [Test]
        public void GroupUpdateTest()
        {
            int index = 0;
            app.Navigator.OpenGroupsPage();
            app.Groups
                .CreateGroupIfEmpty(new GroupData("111", "222", "333"));
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[index];

            app.Groups
                .EditGroups(index)
                .FillGroupForm(new GroupData("111 mod", "222 mod", "333 mod"))
                .SubmitGroupUpdate();
            app.Navigator.OpenGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[index].Group_name = "111 mod";
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id) {
                    Assert.AreEqual(group.Group_name, oldData.Group_name);
                }
            }
        }

        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;
            app.Navigator.OpenGroupsPage();
            app.Groups
                .CreateGroupIfEmpty(new GroupData("1", "2", "3"));
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups
                .SelectGroup(index)
                .DeleteGroups();
            app.Navigator.OpenGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, index);
            }
        }
    }
}
