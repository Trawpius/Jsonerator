using Jsonerator.JsonObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Jsonerator.ClassWriter
{
    public abstract class ClassWriter : IClassWriter
    {
        private string[] includes;

        public ClassWriter()
        {
        }

        public abstract string WriteArray(ArrayObj array);
        public abstract string WriteBracket(bool top = true);
        public abstract string WriteClass(ObjectObj obj);
        public abstract string WriteInclude();
        public abstract string WriteNamespace(string spacename);
        public abstract string WriteProperty(BaseObj prop);
    }
}
