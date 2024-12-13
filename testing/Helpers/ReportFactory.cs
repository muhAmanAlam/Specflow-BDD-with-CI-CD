using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Reflection;
using testing.Factories;

namespace testing.Helpers
{
    public class ReportFactory
    {

        static ExtentReports extent;
        static string path;

        public static void StartFactory()
        {
            string baseDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName;
            path = Path.Combine(baseDirectory, "Report");
            
            extent = new ExtentReports();
            var spark = new ExtentSparkReporter(path + "/" + "TestReport.html");
            spark.LoadJSONConfig(baseDirectory + "/Resources/spark-config.json");
            extent.AttachReporter(spark);

        }

        public static ExtentTest AddNewFeatureInReport(string name)
        {
            return extent.CreateTest<Feature>(name);
        }

        public static ExtentTest AddNewScenarioToFeatureInReport(string scenarioName, ExtentTest reportFeature)
        {
            return reportFeature.CreateNode<Scenario>(scenarioName);
        }

        public static void AddNewStepToFeatureScenarioInReport(bool res, string message, string defType, bool takeSS, ExtentTest reportScenario)
        {
            ExtentTest reportStep;
            switch (defType)
            {
                case "Given":
                    reportStep = reportScenario.CreateNode<Given>(message);
                    break;
                case "When":
                    reportStep = reportScenario.CreateNode<When>(message);
                    break;
                case "And":
                    reportStep = reportScenario.CreateNode<And>(message);
                    break;
                case "Then":
                    reportStep = reportScenario.CreateNode<Then>(message);
                    break;
                default:
                    reportStep = reportScenario.CreateNode<Given>(message);
                    break;
            }
            if (res)
            { 
                reportStep.Log(Status.Pass, "");
                if (takeSS) 
                { 
                    AddSSToReportStep(reportStep); 
                }
                
            }

            else
            {
                reportStep.Log(Status.Fail, "");
                if (takeSS)
                {
                    AddSSToReportStep(reportStep);
                }
            }
        }

        public static void AddSSToReportStep(ExtentTest reportStep) 
        {
            reportStep.Pass(MediaEntityBuilder.CreateScreenCaptureFromBase64String(DriverFactory.TakeSS().AsBase64EncodedString).Build());
        }

        public static void TearDownReportFactory()
        {
            extent.Flush();
        }
    }
}
