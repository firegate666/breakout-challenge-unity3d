using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.TestRunner;

[assembly: TestRunCallback(typeof(PlayModeTestRunCallback))]

public class PlayModeTestRunCallback : ITestRunCallback
{
    public void RunStarted(ITest testsToRun)
    {
    }

    public void RunFinished(ITestResult testResults)
    {
#if !UNITY_EDITOR        
        var result = testResults.ToXml(true);
        var path = Path.GetFullPath(Path.Combine(Application.dataPath, ".//result.xml"));
        var writer = new StreamWriter(path, false);
        writer.Write(
            PrettyXml(
                result.OuterXml
            )
        );
        writer.Close();
#endif
    }

    public void TestStarted(ITest test)
    {
    }

    public void TestFinished(ITestResult result)
    {
        if (!result.Test.IsSuite) Debug.Log($"Result of {result.Name}: {result.ResultState.Status}");
    }

    private static string PrettyXml(string xml)
    {
        var stringBuilder = new StringBuilder();

        var element = XElement.Parse(xml);

        var settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        settings.Indent = true;

        using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
        {
            element.Save(xmlWriter);
        }

        return stringBuilder.ToString();
    }
}