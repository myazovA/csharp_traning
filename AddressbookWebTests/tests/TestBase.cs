﻿using NUnit.Framework;



namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        [SetUp]
        protected void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        protected void TeardownTest()
        {
            app.Stop();
        }
    }
}
