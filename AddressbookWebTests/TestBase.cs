using System;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        [SetUp]
        protected void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }
        [TearDown]
        protected void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        protected void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        protected void ConfirmAddContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }
        protected void FillContactData(ContactData contact)
        {
            FillContactTextField("firstname", contact.Firstname);
            FillContactTextField("middlename", contact.Middlename);
            FillContactTextField("lastname", contact.Lastname);
            FillContactTextField("nickname", contact.Nickname);
            //FillContactTextField("photo", contact.Photo);
            FillContactTextField("title", contact.Title);
            FillContactTextField("company", contact.Company);
            FillContactTextField("address", contact.Address);
            FillContactTextField("home", contact.Home);
            FillContactTextField("mobile", contact.Mobile);
            FillContactTextField("work", contact.Work);
            FillContactTextField("fax", contact.Fax);
            FillContactTextField("email", contact.Email);
            FillContactTextField("email2", contact.Email2);
            FillContactTextField("email3", contact.Email3);
            FillContactTextField("homepage", contact.Homepage);
            /*FillContactTextField("bday", contact.Bday);
            FillContactListField("bmonth", contact.Bmonth);
            FillContactTextField("byear", contact.Byear);
            FillContactListField("aday", contact.Aday);
            FillContactListField("amonth", contact.Amonth);
            FillContactTextField("ayear", contact.Ayear);
            FillContactListField("new_group", contact.New_group);*/
        }
        protected void FillContactListField(string fieldname, string number)
        {
            driver.FindElement(By.Name(fieldname)).Click();
            new SelectElement(driver.FindElement(By.Name(fieldname))).SelectByText(number);
        }
        protected void FillContactTextField(string fieldname, string key)
        {
            driver.FindElement(By.Name(fieldname)).Click();
            driver.FindElement(By.Name(fieldname)).Clear();
            driver.FindElement(By.Name(fieldname)).SendKeys(key);
        }
        protected void GoToAddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        protected void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        protected void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        protected void ChooseGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }


    }
}
