using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("asd");
            newData.Header = "asd";
            newData.Footer = "asd";

            app.Groups.Modify(1, newData);
        }
    }
}
