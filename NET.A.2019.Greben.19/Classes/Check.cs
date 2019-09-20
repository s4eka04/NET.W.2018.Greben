using Day19Course.Interface;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day19Course.Conctet
{
    public class Check : ICheck
    {
        /// <summary>
        /// Logger needed for writes string which is not a URL
        /// </summary>
        Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Check URL contains params
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool CheckUrlOnParam(string url)
        {
            if (url.Contains('='))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check string with help Regex
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool CheckStringOnUrl(string str)
        {
            Regex regex = new Regex(@"\s*https?://(\w*\.\D*/\w*)", RegexOptions.IgnoreCase);
            if (regex.IsMatch(str))
            {
                return true;
            }
            else
            {
                logger.Info(str);
                return false;
            }
        }
    }
}
