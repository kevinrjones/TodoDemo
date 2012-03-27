using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace TodoSpecs
{
    [Binding]
    public class StepDefinitions
    {
        private IWebDriver _webDriver;
 
        [BeforeScenario()]
        public void BeforeScenario()
        {
            _webDriver = new InternetExplorerDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:1398/todo/new");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver.Quit();
        }

        [Given(@"I have entered a title into the form")]        
        public void GivenIHaveEnteredATitleIntoTheForm()
        {
            var elem = _webDriver.FindElement(By.Id("Title"));
            elem.SendKeys("Title");
        }
        
        [Given(@"I have entered an entry into the form")]
        public void GivenIHaveEnteredAnEntryIntoTheForm()
        {
            var elem = _webDriver.FindElement(By.Id("Entry"));
            elem.SendKeys("Entry");
        }
        
        [When(@"I press new")]
        public void WhenIPressNew()
        {
            var elem = _webDriver.FindElement(By.ClassName("form"));
            elem.Submit();
        }

        [Then(@"the todo is listed on the index page")]
        public void ThenTheTodoIsListedOnTheIndexPage()
        {
            var elem = _webDriver.FindElement(By.Id("todolist"));
            Assert.That(elem, Is.Not.Null);
        }

    }
}
