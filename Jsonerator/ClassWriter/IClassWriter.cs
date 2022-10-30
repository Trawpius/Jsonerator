using Jsonerator.JsonObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.ClassWriter
{
    public interface IClassWriter
    {
        string WriteInclude();
        string WriteBracket(bool top);
        string WriteNamespace(string spacename);
        string WriteClass(ObjectObj obj);
        string WriteArray(ArrayObj array);
        string WriteProperty(BaseObj prop);
    }
}
