using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Manager.OpenAddProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//..//tbody/tr/td/a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;

        }

        public void Create(ProjectData project)
        {
            manager.Manager.OpenAddProjectPage();
            InitProjectCreation();
            Type(By.Name("name"), project.Name);
            ConfirmProjectCreation();
        }

        public void ConfirmProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
        }

        public void CreateIfNoProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Manager.OpenAddProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//..//tbody//td/a"));

            if (elements.Count == 0)
            {
                ProjectData newProject = new ProjectData("Project" + TestBase.GenerateRandomString(10));

                Create(newProject);
            }
        }

        public void RemoveProject(ProjectData project)
        {
            manager.Manager.OpenAddProjectPage();
            driver.FindElement(By.LinkText(project.Name)).Click();
            Remove();
            SubmitRemove();
        }

        public void SubmitRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void Remove()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
    }
}