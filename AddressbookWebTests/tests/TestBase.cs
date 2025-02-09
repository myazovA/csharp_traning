using NUnit.Framework;



namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        [SetUp]
        protected void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
