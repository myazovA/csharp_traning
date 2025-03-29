using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        public ManagementMenuHelper Manager { get; private set; }
        public ProjectManagementHelper Project { get; private set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.2.0";
            Manager = new ManagementMenuHelper(this, baseURL);
            Project = new ProjectManagementHelper(this);
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager NewInstance = new ApplicationManager();
                NewInstance.driver.Url = "http://localhost/mantisbt-2.2.0/login_page.php";
                NewInstance.driver.FindElement(By.Name("username")).SendKeys("administrator");
                NewInstance.driver.FindElement(By.Name("password")).SendKeys("root");
                NewInstance.driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                app.Value = NewInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver 
        { 
            get 
            { 
                return driver; 
            }
        }
    }
}
