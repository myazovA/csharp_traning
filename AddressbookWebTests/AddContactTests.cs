using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
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

        [Test]
        public void AddContactWithFirstAndLastName()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddContact();
            ContactData contact = new ContactData();
            contact.Firstname = "Artem";
            contact.Lastname = "Myazov";
            FillContactData(contact);
            ConfirmAddContact();
            ReturnToHomePage();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void ConfirmAddContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        private void FillContactData(ContactData contact)
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

        private void FillContactListField(string fieldname, string number)
        {
            driver.FindElement(By.Name(fieldname)).Click();
            new SelectElement(driver.FindElement(By.Name(fieldname))).SelectByText(number);
        }

        private void FillContactTextField(string fieldname, string key)
        {
            driver.FindElement(By.Name(fieldname)).Click();
            driver.FindElement(By.Name(fieldname)).Clear();
            driver.FindElement(By.Name(fieldname)).SendKeys(key);
        }

        private void GoToAddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
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

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
