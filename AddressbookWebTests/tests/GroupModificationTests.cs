using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Groups.CreateGroupIfNotExist();

            GroupData newData = new GroupData("asd");
            newData.Header = "asd";
            newData.Footer = "asd";

            app.Groups.Modify(1, newData);
        }
    }
}
