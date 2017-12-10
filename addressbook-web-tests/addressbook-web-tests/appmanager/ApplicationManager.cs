using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public LoginHelper Auth { get => loginHelper; set => loginHelper = value; }
        public NavigationHelper Navigator { get => navigationHelper; set => navigationHelper = value; }
        public ContactHelper Contacts { get => contactHelper; set => contactHelper = value; }
        public GroupHelper Groups { get => groupHelper; set => groupHelper = value; }

        private ApplicationManager()
        {
            // FirefoxOptions options = new FirefoxOptions();
            // options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox ESR\firefox.exe";
            // options.UseLegacyImplementation = true;
            // driver = new FirefoxDriver(options);
            driver = new ChromeDriver();
            baseURL = "http://localhost/";

            Auth = new LoginHelper(driver);
            Navigator = new NavigationHelper(driver, baseURL);
            Contacts = new ContactHelper(driver);
            Groups = new GroupHelper(driver);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception) { }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

    }
}
