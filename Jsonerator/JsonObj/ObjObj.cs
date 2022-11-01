using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.JsonObj
{
    public class ObjectObj : BaseObj
    {
        public ObjectObj(string name) : base(name)
        {
            ObjType = ObjType.Object;
        }

        // All properties, including Property, Array and Object classes
        public List<BaseObj> Children { get; set; } = new List<BaseObj>();

        public override List<BaseObj> Traverse()
        {
            List<BaseObj> list = new List<BaseObj>();

            foreach (BaseObj obj in Children)
            {
                if(obj is ObjectObj)
                    list.Add((ObjectObj)obj);
                list.AddRange(obj.Traverse());
            }
            return list;
        }
    }
}
