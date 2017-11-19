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

        public void DeleteGroups()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
        }

        public void SelectGroup(int index)
        {
            string sXpath = String.Format("(//input[@name='selected[]'])[{0}]", index);
            driver.FindElement(By.XPath(sXpath)).Click();
        }

        public void FillNewGroupForm(GroupData groupData)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.Group_name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.Group_header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Group_footer);
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
    }
}
