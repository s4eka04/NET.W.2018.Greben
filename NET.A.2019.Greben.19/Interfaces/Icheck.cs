using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19Course.Interface
{
    public interface ICheck
    {
        bool CheckUrlOnParam(string url);
        bool CheckStringOnUrl(string str);
    }
}
