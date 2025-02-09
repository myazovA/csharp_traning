using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("1");
            group.Header = "1";
            group.Footer = "1";

            app.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");

            app.Groups.Create(group);
        }
    }
}
