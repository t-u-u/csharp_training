using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

namespace WebAddressbookTests
{
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox ESR\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(10);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData();
            contact.FirstName = "1";
            contact.MiddleName = "2";
            contact.LastName = "3";
            contact.Nickname = "4";
            contact.PhotoPath = "c:\\temp\\1.gif";
            contact.Title = "5";
            contact.Company = "6";
            contact.Address = "7";
            contact.PhoneHome = "8";
            contact.PhoneMobile = "9";
            contact.PhoneWork = "10";
            contact.PhoneFax = "11";
            contact.Email = "12";
            contact.Email2 = "13";
            contact.Email3 = "14";
            contact.Homepage = "15";
            contact.Birthday = new ContactData.Date("1", "January", "1234");
            contact.Anniversary = new ContactData.Date("1", "January", "2345");
            contact.Group = "[none]";
            contact.SecondaryAddress = "16";
            contact.Notes = "17";
            contact.SecondaryHome = "18";

            FillNewContactForm(contact);
            SubmitContactForm();
            OpenHomePage();
        }

        private void SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void Login(AccountData accountData)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(accountData.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(accountData.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillNewContactForm(ContactData contactData)
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

        private void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
