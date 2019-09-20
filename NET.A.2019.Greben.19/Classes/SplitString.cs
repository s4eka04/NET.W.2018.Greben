using Day19Course.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19Course.Conctet
{
    public class SplitString : ISplitString
    {

        /// <summary>
        /// Convert part of string is a params to array 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>array key and value</returns>
        public string[] SplitOnParameters(string str)
        {
            return str.Split('=', '&');
        }

        /// <summary>
        /// split string by slesh
        /// </summary>
        /// <param name="str"></param>
        /// <returns>array elements</returns>
        public string[] SplitBySlesh(string str)
        {
            return str.Split('/', '?');
        }
    }
}
