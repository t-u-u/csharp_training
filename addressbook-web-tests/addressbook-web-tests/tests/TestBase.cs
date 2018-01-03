using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int len = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 223) + 32));
            }
            return builder.ToString();
        }

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            app.Navigator.OpenHomePage();
        }

        [TearDown]
        public void TeardownTest()
        {
            
        }
    }
}
