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
            NavigateToURL(baseURL);
            return this;
        }
        public NavigationHelper ReturnToHomePage()
        {
            ClickElementWithText("home page");
            return this;
        }
        public NavigationHelper GoToAddContact()
        {
            ClickElementWithText("add new");
            return this;
        }
        public NavigationHelper GoToGroupPage()
        {
            ClickElementWithText("groups");
            return this;
        }
        public NavigationHelper ReturnToGroupPage()
        {
            ClickElementWithText("group page");
            return this;
        }
    }
}
