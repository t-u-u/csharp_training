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

        public void SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void FillNewContactForm(ContactData contactData)
        {
            if (contactData.FirstName != null)
            {
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys(contactData.FirstName);
            }
            if (contactData.MiddleName != null)
            {
                driver.FindElement(By.Name("middlename")).Clear();
                driver.FindElement(By.Name("middlename")).SendKeys(contactData.MiddleName);
            }
            if (contactData.LastName != null)
            {
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(contactData.LastName);
            }
            if (contactData.Nickname != null)
            {
                driver.FindElement(By.Name("nickname")).Clear();
                driver.FindElement(By.Name("nickname")).SendKeys(contactData.Nickname);
            }
            if (contactData.PhotoPath != null)
            {
                driver.FindElement(By.Name("photo")).SendKeys(contactData.PhotoPath);
            }
            if (contactData.Title != null)
            {
                driver.FindElement(By.Name("title")).Clear();
                driver.FindElement(By.Name("title")).SendKeys(contactData.Title);
            }
            if (contactData.Company != null)
            {
                driver.FindElement(By.Name("company")).Clear();
                driver.FindElement(By.Name("company")).SendKeys(contactData.Company);
            }
            if (contactData.Address != null)
            {
                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(contactData.Address);
            }
            if (contactData.PhoneHome != null)
            {
                driver.FindElement(By.Name("home")).Clear();
                driver.FindElement(By.Name("home")).SendKeys(contactData.PhoneHome);
            }
            if (contactData.PhoneMobile != null)
            {
                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(contactData.PhoneMobile);
            }
            if (contactData.PhoneWork != null)
            {
                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(contactData.PhoneWork);
            }
            if (contactData.PhoneFax != null)
            {
                driver.FindElement(By.Name("fax")).Clear();
                driver.FindElement(By.Name("fax")).SendKeys(contactData.PhoneFax);
            }
            if (contactData.Email != null)
            {
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(contactData.Email);
            }
            if (contactData.Email2 != null)
            {
                driver.FindElement(By.Name("email2")).Clear();
                driver.FindElement(By.Name("email2")).SendKeys(contactData.Email2);
            }
            if (contactData.Email3 != null)
            {
                driver.FindElement(By.Name("email3")).Clear();
                driver.FindElement(By.Name("email3")).SendKeys(contactData.Email3);
            }
            if (contactData.Homepage != null)
            {
                driver.FindElement(By.Name("homepage")).Clear();
                driver.FindElement(By.Name("homepage")).SendKeys(contactData.Homepage);
            }
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
            {
                driver.FindElement(By.Name("address2")).Clear();
                driver.FindElement(By.Name("address2")).SendKeys(contactData.SecondaryAddress);
            }
            if (contactData.Notes != null)
            {
                driver.FindElement(By.Name("notes")).Clear();
                driver.FindElement(By.Name("notes")).SendKeys(contactData.Notes);
            }
            if (contactData.SecondaryHome != null)
            {
                driver.FindElement(By.Name("phone2")).Clear();
                driver.FindElement(By.Name("phone2")).SendKeys(contactData.SecondaryHome);
            }
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
