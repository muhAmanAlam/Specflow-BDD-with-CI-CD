using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using TechTalk.SpecFlow;
using testing.Factories;
using testing.Helpers;

namespace testing.StepDefinitions
{
    [Binding]
    public class Hooks
    {

        private static ExtentTest currentFeature;
        private ExtentTest currentScenario;

        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportFactory.StartFactory();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            currentFeature = ReportFactory.AddNewFeatureInReport(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            currentScenario = ReportFactory.AddNewScenarioToFeatureInReport(scenarioContext.ScenarioInfo.Title, currentFeature);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {

            bool stepResult = scenarioContext.StepContext.Status.ToString().Equals("OK");
            
            string definitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            try {
                if ((bool) scenarioContext["apiTest"] == true)
                {
                    ReportFactory.AddNewStepToFeatureScenarioInReport(stepResult, scenarioContext.StepContext.StepInfo.Text, definitionType, false, currentScenario);
                }
            }
            catch 
            {
                ReportFactory.AddNewStepToFeatureScenarioInReport(stepResult, scenarioContext.StepContext.StepInfo.Text, definitionType, true, currentScenario);
            }

        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext) 
        {
            try
            {
                if ((bool) scenarioContext["apiTest"] == true)
                {
                    currentScenario.CreateNode<Asterisk>("Complete Request URL").Pass(MarkupHelper.CreateLabel((string)_scenarioContext["responseURI"], ExtentColor.Blue));
                    currentScenario.CreateNode<Asterisk>("Response Code:").Pass(MarkupHelper.CreateLabel((string)_scenarioContext["responseCode"], ExtentColor.Blue));
                    currentScenario.CreateNode<Asterisk>("Response Body:").Pass(MarkupHelper.CreateCodeBlock((string)_scenarioContext["responseContent"], CodeLanguage.Json));
                }
            }
            catch 
            {
            }

            if (DriverFactory.driver != null)
            {
                DriverFactory.TearDownDriver();
            }

        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            if (DriverFactory.driver != null)
            {
                DriverFactory.TearDownDriver();
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ReportFactory.TearDownReportFactory();
        }
    }
}
