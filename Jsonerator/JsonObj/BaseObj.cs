using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.JsonObj
{
    public abstract class BaseObj
    {
        public BaseObj(string name)
        {
            Name = name;
            ObjType = ObjType.Null;
        }
        public string Name { get; set; }
        public ObjType ObjType { get; set; }

        public abstract List<BaseObj> Traverse();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not BaseObj)
                return false;
            if (ObjType == ObjType.Null)
                return false;

            BaseObj convObj = (BaseObj)obj;
            bool samename = (Name.ToLower().Equals(convObj.Name.ToLower()));
            bool sametype = ObjType == convObj.ObjType;

            return samename && sametype;
        }
    }
}
