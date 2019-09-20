using Day19Course.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day19Course.Conctet
{
    public class URLtoXML: IURLtoXML
    {
        /// <summary>
        /// Split URL on elements
        /// </summary>
        List<string> elements;

        /// <summary>
        /// Split URL on parameters
        /// </summary>
        Dictionary<string, string> parameters;

        /// <summary>
        /// Path to text file
        /// </summary>
        private readonly string textFile;

        /// <summary>
        /// Path to xml file
        /// </summary>
        private readonly string xmlFile;

        /// <summary>
        /// Constructor  with two params
        /// </summary>
        /// <param name="text"></param>
        /// <param name="xml"></param>
        public URLtoXML(string text, string xml)
        {
            textFile = text;
            xmlFile = xml;
        }


        /// <summary>
        /// Method Reads from text file and Writtes to Xml file
        /// </summary>
        /// <param name="check"></param>
        /// <param name="split"></param>
        public void Go(ICheck check, ISplitString split)
        {
            if(check == null)
            {
                check = new Check();
            }
            if(split == null)
            {
                split = new SplitString();
            }
            
            using (StreamReader sr = new StreamReader(textFile))
            {
                string line;

                XDocument xDoc;
                XElement root;
                if (!File.Exists(xmlFile))
                {
                    File.Delete(xmlFile);
                }
                

                xDoc = new XDocument();
                root = new XElement("urlAddresses");

                while ((line = sr.ReadLine()) != null)
                {
                    ITextToElement textToElement = new TxtToElement(line, check, split);
                    elements = textToElement.GetElementsList();
                    parameters = textToElement.GetParametresDictionary();
                    if(elements == null)
                    {
                        continue;
                    }

                    XElement address = new XElement("urlAdress");
                    XElement host = new XElement("host", new XAttribute("name", elements[0]));

                    elements.RemoveAt(0);
                    XElement uri = new XElement("uri");
                    address.Add(host, uri);

                    foreach (var elem in elements)
                    {
                        if (elem != string.Empty)
                        {
                            XElement segment = new XElement("segment", elem);
                            uri.Add(segment);
                        }
                    }

                    if (parameters != null)
                    {
                        XElement parametersElement = new XElement("parameters");
                        address.Add(parametersElement);

                        foreach (var param in parameters)
                        {
                            XElement parametr = new XElement("parametr", new XAttribute("value", param.Value), new XAttribute("key", param.Key));
                            parametersElement.Add(parametr);
                        }
                    }
                    
                    root.Add(address);
                    


                }
                xDoc.Add(root);
                xDoc.Save("urlAddresses.xml");
            }
        }

    }
}
