using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace testing.Helpers
{
    internal class XmlReaderUtility
    {
        static string path => GetCurrentPath();

        public static string GetCurrentPath() {
            string baseDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName;
            return  Path.Combine(baseDirectory, "Resources", "Elements.xml");
        }
        

        public static string GetValueUsingNodePath(string nodePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            Console.WriteLine(nodePath);
            Console.WriteLine(path);
            return doc.DocumentElement.SelectSingleNode(nodePath).InnerText
;        }

        public static string GetValueUsingNodeKey(string key)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            return doc.DocumentElement.SelectSingleNode("//*[@key='"+key+"']").Attributes["value"].InnerText
;
        }

    }
}
