﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AuthTestBase : TestBase
    {

        [SetUp]
        public void SetupTest()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
