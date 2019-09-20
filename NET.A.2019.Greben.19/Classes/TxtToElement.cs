using Day19Course.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19Course.Conctet
{
    public class TxtToElement : ITextToElement
    {
        /// <summary>
        /// Url read from text file, one line
        /// </summary>
        string url;

        /// <summary>
        /// Elements Url
        /// </summary>
        List<string> elements;

        /// <summary>
        /// Parameters URL
        /// </summary>
        Dictionary<string, string> parameters;

        /// <summary>
        /// Constructor with tree params host interfaces
        /// </summary>
        /// <param name="url"></param>
        /// <param name="check"></param>
        /// <param name="split"></param>
        public TxtToElement(string url,ICheck check, ISplitString split)
        {
            this.url = url;
            if (CheckOnUrl(check))
            {
                SplitOnElementsAndParams(check, split);
            }
            else
            {
                elements = null;
                parameters = null;
            }
        }

        /// <summary>
        /// Check elements and return
        /// </summary>
        /// <returns>if dont have elements return null</returns>
        public List<string> GetElementsList()
        {
            if (elements != null)
            {
                elements.RemoveRange(0, 2);
            }
            return elements; 
        }

        /// <summary>
        /// Check params and return
        /// </summary>
        /// <returns>if dont have params return null</returns>
        public Dictionary<string, string> GetParametresDictionary()
        {
            return parameters;
        }


        /// <summary>
        /// Split received  string on elements and params
        /// </summary>
        /// <param name="check"></param>
        /// <param name="split"></param>
        public void SplitOnElementsAndParams(ICheck check, ISplitString split)
        {
            elements = new List<string>();
            foreach (var str in split.SplitBySlesh(url))
            {
                if (check.CheckUrlOnParam(str))
                {
                    parameters = new Dictionary<string, string>();
                    string[] keyValue = split.SplitOnParameters(str);
                    for (int i = 0; i < keyValue.Length - 1; i += 2)
                    {
                        parameters.Add(keyValue[i], keyValue[i + 1]);
                    }
                }
                else
                {
                    elements.Add(str);
                }
            }
        }

        /// <summary>
        /// Check string is URL
        /// </summary>
        /// <param name="check"></param>
        /// <returns>true if string is URL</returns>
        private bool CheckOnUrl(ICheck check)
        {
            return check.CheckStringOnUrl(url);
        }
    }
}
