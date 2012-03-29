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
        [Given(@"I change its title")]
        public void GivenIHaveEnteredATitleIntoTheForm()
        {
            var elem = _webDriver.FindElement(By.Id("Title"));
            elem.Clear();
            elem.SendKeys("Goodbye");
        }

        [Given(@"I have entered an entry into the form")]
        public void GivenIHaveEnteredAnEntryIntoTheForm()
        {
            var elem = _webDriver.FindElement(By.Id("Entry"));
            elem.SendKeys("Entry");
        }

        [When(@"I press new")]
        [When(@"I press update")]
        public void WhenIPressNew()
        {
            var elem = _webDriver.FindElement(By.ClassName("form"));
            elem.Submit();
        }

        [Then(@"the todo is listed on the index page")]
        [Then(@"the updated title is displayed")]
        public void ThenTheTodoIsListedOnTheIndexPage()
        {
            var elem = _webDriver.FindElement(By.Id("todolist"));
            Assert.That(elem, Is.Not.Null);
        }

        [Given(@"I am on the index page")]
        public void GivenIAmOnTheIndexPage()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:1398/");
       }

        [Given(@"I select an item to be edited")]
        public void GivenISelectAnItemToBeEdited()
        {
            var elem = _webDriver.FindElement(By.LinkText("Goodbye"));
            elem.Click();
        }
    }
}
