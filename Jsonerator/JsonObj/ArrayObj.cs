using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.JsonObj
{
    public class ArrayObj : BaseObj
    {
        public ArrayObj(string name) : base(name)
        {
            ObjType = ObjType.Array;
        }

        public ArrayObj(string name, BaseObj indType) : base(name)
        {
            ObjType = ObjType.Array;
            IndexType = indType;
        }
        public BaseObj IndexType { get; set; }
    }    
}
