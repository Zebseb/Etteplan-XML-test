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
        public XDocument xmlDoc { get; set; } = new();

        public XMLReader()
        {
            XDocument? xmlDocument = XDocument.Load("XMLFile1.xml");
            xmlDoc = xmlDocument;
        }

        public string GetElementById(string id)
        {
            string targetWord = IsValidId(id);

            if (!string.IsNullOrEmpty(targetWord))
            {
                return targetWord;
            }

            else
            {
                return "Target word was not found...";
            }
        }

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

                else
                {
                    return "";
                }
            }

            return "";
        }
    }
}