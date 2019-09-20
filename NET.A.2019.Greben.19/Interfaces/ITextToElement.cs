using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19Course.Interface
{
    public interface ITextToElement
    {
        List<string> GetElementsList();

        Dictionary<string, string> GetParametresDictionary();

        void SplitOnElementsAndParams(ICheck check, ISplitString split);

    }
}
