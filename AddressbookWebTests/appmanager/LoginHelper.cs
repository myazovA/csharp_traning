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
            ClickElementWithName("user");
            ClearElementWithName("user");
            SendKeysToElementWithName("user", account.Username);
            ClickElementWithName("pass");
            ClearElementWithName("pass");
            SendKeysToElementWithName("pass", account.Password);
            ClickElementWithXPATH("//input[@value='Login']");
            return this;
        }
        public LoginHelper Logout()
        {
            ClickElementWithText("Logout");
            return this;
        }
    }
}