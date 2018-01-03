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

        internal ContactData getContactInfoFromTable(int index)
        {
            //manager.Navigator.OpenHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            ContactData contact = new ContactData();
            contact.LastName = cells[1].Text;
            contact.FirstName = cells[2].Text;
            contact.Address = cells[3].Text;
            contact.AllEmails = cells[4].Text;
            contact.AllPhones = cells[5].Text;

            return contact;
        }

        internal ContactData getContactInfoFromEditForm(int index)
        {
            //manager.Navigator.OpenHomePage();
            EditContact(index);
            ContactData contact = new ContactData();
            contact.FirstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            contact.MiddleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            contact.LastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            contact.Nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            contact.Title = driver.FindElement(By.Name("title")).GetAttribute("value");
            contact.Company = driver.FindElement(By.Name("company")).GetAttribute("value");
            contact.Address = driver.FindElement(By.Name("address")).GetAttribute("value");
            contact.PhoneHome = driver.FindElement(By.Name("home")).GetAttribute("value");
            contact.PhoneMobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            contact.PhoneWork = driver.FindElement(By.Name("work")).GetAttribute("value");
            contact.PhoneFax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            contact.Email = driver.FindElement(By.Name("email")).GetAttribute("value");
            contact.Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            contact.Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            contact.Homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            contact.Birthday = new ContactData.Date(driver.FindElement(By.Name("bday")).GetAttribute("value"),
                driver.FindElement(By.Name("bmonth")).GetAttribute("value"),
                driver.FindElement(By.Name("byear")).GetAttribute("value"));
            contact.Anniversary = new ContactData.Date(driver.FindElement(By.Name("aday")).GetAttribute("value"),
                driver.FindElement(By.Name("amonth")).GetAttribute("value"),
                driver.FindElement(By.Name("ayear")).GetAttribute("value"));
            contact.SecondaryAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            contact.Notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            contact.SecondaryHome = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            return contact;
        }

        internal ContactData getContactInfoFromDetailsForm(int index)
        {
            //manager.Navigator.OpenHomePage();
            OpenContactDetails(index);
            ContactData contact = new ContactData();
            contact.FullDetails = driver.FindElement(By.CssSelector("div#content")).Text;
            return contact;
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

        public ContactHelper OpenContactDetails(int index)
        {
            string sXpath = String.Format("//img[@title='Details'][{0}]", index + 1);
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
