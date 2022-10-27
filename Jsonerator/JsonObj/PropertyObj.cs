using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.JsonObj
{
    public class PropertyObj : BaseObj
    {
        public PropertyObj(string name, ObjType objType) : base(name)
        {
            ObjType = objType;
        }
    }
}

