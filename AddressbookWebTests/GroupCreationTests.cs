using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("1");
            group.Header = "1";
            group.Footer = "1";
            FillGroupForm(group);
            SubmitGroupCreation();
            Logout();
        }
    }
}
