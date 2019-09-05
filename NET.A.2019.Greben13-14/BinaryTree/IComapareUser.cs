using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_greben_13_14
{
    public interface IComapareUser<T>
    {
        int CompareTo(T t1);
    }
}
