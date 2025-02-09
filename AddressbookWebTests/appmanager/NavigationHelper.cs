using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public  class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public NavigationHelper OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return this;
            }
            NavigateToURL(baseURL);
            return this;
        }
        public NavigationHelper ReturnToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return this;
            }
            ClickElementWithText("home page");
            return this;
        }
        public NavigationHelper GoToAddContact()
        {
            if (driver.Url == baseURL + "/edit.php"
                && IsElementPresent(By.Name("submit")))
            {
                return this;
            }
            ClickElementWithText("add new");
            return this;
        }
        public NavigationHelper GoToGroupPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return this;
            }
            ClickElementWithText("groups");
            return this;
        }
        public NavigationHelper ReturnToGroupPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return this;
            }
            ClickElementWithText("group page");
            return this;
        }
    }
}
