using System;
using System.Collections.Generic;
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
            manager.Navigator.ReturnToGroupPage();
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

        public void CreateGroupIfNotExist()
        {
            manager.Navigator.GoToGroupPage();
            if (!IsElementPresent(By.XPath("//div[@id='content']/form/span/input")))
            {
                GroupData baseGroup = new GroupData("0");
                Create(baseGroup);
            }
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
            Type("group_name", group.Name);
            Type("group_header", group.Header);
            Type("group_footer", group.Footer);
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
            ClickElementWithXPATH("//div[@id='content']/form/span[" + (index+1) + "]/input");
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupPage();
            List<GroupData> groups = new List<GroupData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
