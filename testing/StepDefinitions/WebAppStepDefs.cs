using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using testing.Factories;
using testing.Helpers;

namespace testing.StepDefinitions
{
    [Binding]
    public class WebAppStepDefs
    {
        private readonly ScenarioContext _scenarioContext;

        public WebAppStepDefs(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given("User Navigates to (.*)")]   
        public void GivenUserNavigatesToUrl(string url)
        {
            DriverFactory.LauchDriver(debuggingMode: false);
            Utilities.NavigateDriver(url);
        }

        [When("User Enters (.*) in '(.*)'")]
        public static void WhenUserEntersUsernameOnUsernameXpathOnSauceDemoWebsite(string data, string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            Utilities.EnterString(locator, data);
        }


        [Then("User Enters (.*) in '(.*)'")]
        public void WhenUserEntersPasswordOnPasswodXpathOnSauceDemoWebsite(string data, string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            WaitFactory.WaitForElementToBeVisible(locator);
            Utilities.EnterString(locator, data);
        }

        [Then("User Enters (.*) in '(.*)'.")]
        public void WhenUserEntersUsingAction(string data, string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            WaitFactory.WaitForElementToBeVisible(locator);
            Utilities.EnterStringUsingAction(locator, data);
        }

        [When("User Hovers over '(.*)'")]
        public void WhenUserHoversOverUsingAction(string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            WaitFactory.WaitForElementToBeVisible(locator);
            Utilities.HoverUsingAction(locator);
        }

        [When("User Clicks on {string}")]
        public void WhenUserClicksOn(string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            WaitFactory.WaitForElementToBeClickable(locator);
            Utilities.ClickElement(locator);
        }

        [Then("User Clicks on '(.*)'")]
        public void ThenUserClicksOnLoginButtonXpathOnSauceDemoWebsite(string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            WaitFactory.WaitForElementToBeClickable(locator);
            Utilities.ClickElement(locator);
        }

        [Then("{string} should be visible")]
        public void ThenShouldBeDisplayed(string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            Assert.True(Utilities.IsElementVisible(locator));   
        }

        [When("{string} is not visible")]
        public void ThenShouldNotBeDisplayed(string nodeKey)
        {
            string locator = XmlReaderUtility.GetValueUsingNodeKey(nodeKey);
            Assert.True(Utilities.IsElementNotVisible(locator));
        }
    }
}
