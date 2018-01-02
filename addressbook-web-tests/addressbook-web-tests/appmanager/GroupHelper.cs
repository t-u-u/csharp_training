using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base(driver) { }


        public GroupHelper DeleteGroups()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            // manager.Navigator.OpenGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public GroupHelper EditGroups(int index)
        {
            string checkboxXpath = String.Format("(//input[@name='selected[]'])");
            driver.FindElements(By.XPath(checkboxXpath))[index].Click();
            string sXpath = String.Format("(//input[@name='edit'])[1]");
            driver.FindElement(By.XPath(sXpath)).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            string sXpath = String.Format("(//input[@name='selected[]'])[{0}]", index + 1);
            driver.FindElement(By.XPath(sXpath)).Click();
            return this;
        }

        public int CountGroups()
        {
            return driver.FindElements(By.XPath("//input[@name='selected[]']")).Count;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Group_name);
            Type(By.Name("group_header"), groupData.Group_header);
            Type(By.Name("group_footer"), groupData.Group_footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper CreateGroupIfEmpty(GroupData groupData)
        {
            if (CountGroups() == 0)
            {
                CreateGroup(groupData);
                manager.Navigator.OpenGroupsPage();
            }
            return this;
        }

        public GroupHelper CreateGroup(GroupData groupData)
        {
            this.InitGroupCreation()
                .FillGroupForm(groupData)
                .SubmitGroupCreation();
            return this;
        }
    }
}
