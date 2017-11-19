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
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        private LoginHelper loginHelper;
        private NavigationHelper navigationHelper;
        private ContactHelper contactHelper;
        private GroupHelper groupHelper;

        public LoginHelper Auth { get => loginHelper; set => loginHelper = value; }
        public NavigationHelper Navigator { get => navigationHelper; set => navigationHelper = value; }
        public ContactHelper Contacts { get => contactHelper; set => contactHelper = value; }
        public GroupHelper Groups { get => groupHelper; set => groupHelper = value; }

        public ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox ESR\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";

            Auth = new LoginHelper(driver);
            Navigator = new NavigationHelper(driver, baseURL);
            Contacts = new ContactHelper(driver);
            Groups = new GroupHelper(driver);
        }

        public void AppStop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
