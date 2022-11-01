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

        public override List<BaseObj> Traverse()
        {
            List<BaseObj> list = new List<BaseObj>();
            if (IndexType is ObjectObj)
            {
                list.Add((ObjectObj)IndexType);
                list.AddRange(IndexType.Traverse());
            }
            if (IndexType is ArrayObj)
            {
                list.AddRange(IndexType.Traverse());
            }
            
            return list;
        }
    }    
}
