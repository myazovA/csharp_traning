using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public LoginHelper Login(AccountData account)
        {
            if (IsLoggedIn())
            {

                if (IsLoggedin(account))
                {
                    return this;
                }
                Logout();
            }
            Type("user", account.Username);
            Type("pass", account.Password);
            ClickElementWithXPATH("//input[@value='Login']");
            return this;
        }

        public bool IsLoggedin(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                ClickElementWithText("Logout");
            }
            return this;
        }
    }
}