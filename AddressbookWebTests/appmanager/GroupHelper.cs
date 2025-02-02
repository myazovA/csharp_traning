using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Auth.Logout();
            return this;
        }
        public GroupHelper Remove(int num)
        {
            manager.Navigator.GoToGroupPage();
            ChooseGroup(num);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }
        public GroupHelper Modify(int num, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            ChooseGroup(num);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            ClickElementWithName("update");
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            ClickElementWithName("edit");
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            ClickElementWithName("submit");
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            ClickElementWithName("group_name");
            ClearElementWithName("group_name");
            SendKeysToElementWithName("group_name", group.Name);
            ClickElementWithName("group_header");
            ClearElementWithName("group_header");
            SendKeysToElementWithName("group_header", group.Header);
            ClickElementWithName("group_footer");
            ClearElementWithName("group_footer");
            SendKeysToElementWithName("group_footer", group.Footer);
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            ClickElementWithName("new");
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            ClickElementWithName("delete");
            return this;
        }
        public GroupHelper ChooseGroup(int index)
        {
            ClickElementWithXPATH("//div[@id='content']/form/span[" + index + "]/input");
            return this;
        }
    }
}
