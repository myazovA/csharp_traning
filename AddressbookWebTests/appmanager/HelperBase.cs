using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public void ClickElementWithText(string text)
        {
            driver.FindElement(By.LinkText(text)).Click();
        }
        public void ClickElementWithName(string name)
        {
            driver.FindElement(By.Name(name)).Click();
        }
        public void ClickElementWithXPATH(string XPATH)
        {
            driver.FindElement(By.XPath(XPATH)).Click();
        }
        public void ClickElementWithID(string ID)
        {
            driver.FindElement(By.Id(ID)).Click();
        }
        public void NavigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        public void ClearElementWithName(string name)
        {
            driver.FindElement(By.Name(name)).Clear();
        }
        public void SendKeysToElementWithName(string name, string key)
        {
            driver.FindElement(By.Name(name)).SendKeys(key);
        }
        public void SelectElementFromList(string name, string number)
        {
            new SelectElement(driver.FindElement(By.Name(name))).SelectByText(number);
        }
        public void Type(string locator, string text)
        {
            if (text != null)
            {
                ClickElementWithName(locator);
                ClearElementWithName(locator);
                SendKeysToElementWithName(locator, text);
            }
        }
        public bool IsElementPresent(By by)
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
        public void FillContactListField(string fieldname, string number)
        {
            if (number != null)
            {
                ClickElementWithName(fieldname);
                SelectElementFromList(fieldname, number);
            }
        }
    }
}