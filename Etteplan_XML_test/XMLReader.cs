using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Etteplan_XML_test
{
    public class XMLReader
    {
        // Creates a new property of a XDocument
        public XDocument xmlDoc { get; set; } = new();
        private string xmlFile = "XMLFile1.xml";

        // Load info from the xml file to the XDocument
        public XMLReader()
        {
            string path = Path.Combine(Environment.CurrentDirectory, xmlFile);

            XDocument? xmlDocument = XDocument.Load(path);
            xmlDoc = xmlDocument;
        }

        // Get the target value by id
        public string GetTargetValueById(string id)
        {
            string targetWord = IsValidId(id);

            if (!string.IsNullOrEmpty(targetWord))
            {
                return targetWord;
            }

            return "Target word was not found...";
        }

        // Check if the id is valid and if there is a value to get
        private string IsValidId(string id)
        {
            string targetValue;

            XElement? elementById = xmlDoc.XPathSelectElement($"//trans-unit[@id='{id}']");

            if (elementById != null)
            {
                XElement? elementByString = elementById.XPathSelectElement("target");

                if (elementByString != null)
                {
                    targetValue = elementByString.Value;
                    return targetValue;
                }
            }

            return "";
        }
    }
}