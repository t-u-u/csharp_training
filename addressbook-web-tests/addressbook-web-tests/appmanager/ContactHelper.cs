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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver) { }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            ContactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("middlename"), contactData.MiddleName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("nickname"), contactData.Nickname);
            
            if (contactData.PhotoPath != null)
            {
                driver.FindElement(By.Name("photo")).SendKeys(contactData.PhotoPath);
            }
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.PhoneHome);
            Type(By.Name("mobile"), contactData.PhoneMobile);
            Type(By.Name("work"), contactData.PhoneWork);
            Type(By.Name("fax"), contactData.PhoneFax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("homepage"), contactData.Homepage);
            
            if (contactData.Birthday != null)
            {
                new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactData.Birthday.Day);
                new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactData.Birthday.Month);
                driver.FindElement(By.Name("byear")).Clear();
                driver.FindElement(By.Name("byear")).SendKeys(contactData.Birthday.Year);
            }
            if (contactData.Anniversary != null)
            {
                new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactData.Anniversary.Day);
                new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactData.Anniversary.Month);
                driver.FindElement(By.Name("ayear")).SendKeys(contactData.Anniversary.Year);
            }
            if (contactData.Group != null)
            {
                new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contactData.Group);
            }
            if (contactData.SecondaryAddress != null)
            Type(By.Name("address2"), contactData.SecondaryAddress);
            Type(By.Name("notes"), contactData.Notes);
            Type(By.Name("phone2"), contactData.SecondaryHome);
            
            return this;
        }

        private List<ContactData> ContactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (ContactCache == null)
            {
                ContactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> parts = element.FindElements(By.TagName("td"));
                    ContactData contact = new ContactData();
                    contact.FirstName = parts[2].Text;
                    contact.LastName = parts[1].Text;
                    ContactCache.Add(contact);
                }
            }
            return new List<ContactData>(ContactCache);
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            string sXpath = String.Format("(//input[@name='selected[]'])[{0}]", index + 1);
            driver.FindElement(By.XPath(sXpath)).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {    
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            ContactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            string sXpath = String.Format("//img[@title='Edit'][{0}]", index + 1);
            driver.FindElement(By.XPath(sXpath)).Click();
            return this;
        }

        public int CountClients()
        {
            return driver.FindElements(By.XPath("//input[@name='selected[]']")).Count;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            InitContactCreation()
                .FillContactForm(contact)
                .SubmitContactForm();
            return this;
        }

        public ContactHelper CreateContactIfEmpty(ContactData contact)
        {
            if (CountClients() == 0)
            {
                CreateContact(contact);
                manager.Navigator.OpenHomePage();
            }
            return this;
        }
    }
}
