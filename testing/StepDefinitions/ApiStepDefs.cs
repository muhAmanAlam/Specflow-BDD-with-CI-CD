using NUnit.Framework;
using System;
using System.Net.Mail;
using System.Security.Policy;
using TechTalk.SpecFlow;
using testing.Helpers;

namespace testing.StepDefinitions
{
    [Binding]
    public class ApiStepDefs
    {
        private readonly ScenarioContext _scenarioContext;

        public ApiStepDefs(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When("I set url to '(.*)'")]
        public void WhenISetUrlTo(string baseUrl)
        {
            APIUtilities.SetupClient(baseUrl);
            _scenarioContext["apiTest"] = true;
        }

        [When("I set endpoint to '(.*)'")]
        public void WhenISetEndpointTo(string endPoint)
        {
            APIUtilities.SetupRequest(endPoint);
        }

        [When("Add '(.*)' to '(.*)' in request header")]
        public void WhenRequestHeaderIs(string key, string value)
        {
            APIUtilities.AddToHeader(key, value);
        }

        [When("Add parameter '(.*)' with value '(.*)' to request")]
        public void WhenRequestBodyIs(string key, string value)
        {
            APIUtilities.AddParameterToRequest(key, value);
        }

        [When("Add json request body '(.*)' to request")]
        public void WhenAddRequestBodyToRequest(string requestBody)
        {
            APIUtilities.AddRequestBody(requestBody);
        }

        [When("I execute a '(.*)' request")]
        public void WhenIExecuteARequest(string requestMethod)
        {
            APIUtilities.AddRequestMethod(requestMethod);
            APIUtilities.ExecuteRequest();
            _scenarioContext["responseURI"] = APIUtilities.GetResponseURI();
            _scenarioContext["responseCode"] = APIUtilities.GetResponseCode().ToString();
            _scenarioContext["responseContent"] = APIUtilities.GetResponseContent();
        }



        [Then("I get a '(.*)' response code")]
        public void ThenIGetAResponseCode(String code)
        {
            APIUtilities.ExecuteRequest();
            Assert.AreEqual(code, APIUtilities.GetResponseCode().ToString());
        }
    }
}
