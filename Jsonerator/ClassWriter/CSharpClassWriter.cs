using Jsonerator.JsonObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.ClassWriter
{
    public class CSharpClassWriter : ClassWriter
    {
        private string[] includes = { "System", "System.Linq", "System.Text" };

        public override string WriteArray(ArrayObj array)
        {
            string format = $"public {{0}}[] {{1}}";
            string tail = $"{{get; set;}} {Environment.NewLine}";
            string name = array.Name;
            string indtype = "";

            BaseObj obj = array.IndexType;

            if(obj.ObjType==ObjType.Object)
                indtype = obj.Name;
            else
                indtype = obj.ObjType.ToString();

            return string.Format(format, indtype, name) + tail;
        }

        public override string WriteBracket(bool top = true)
        {
            if (top)
                return $"{{{Environment.NewLine}";
            else
                return $"}}{Environment.NewLine}";
        }

        public override string WriteClass(ObjectObj obj)
        {
            string head = $"public class {obj.Name}{Environment.NewLine}" +
                WriteBracket(true);

            string body = "";
            string bodyformat = $"{{0}}{Environment.NewLine}";
            foreach(BaseObj child in obj.Children)
            {
                if(child.ObjType==ObjType.Array)
                    body += string.Format(bodyformat, WriteArray((ArrayObj)child));
                else
                    body += string.Format(bodyformat, WriteProperty(child));
            }
            body += WriteBracket(false);

            return head + body;
        }

        // better storage for includes later
        public override string WriteInclude()
        {
            string format = $"using {{0}};{Environment.NewLine}";
            string output = "";

            foreach(string include in includes)
            {
                output += string.Format(format, include);
            }
            
            return output;
        }

        public override string WriteNamespace(string spacename)
        {
            // String format messes up when you need to use the actual bracket character. Nightmares nightmares nightmares
            string format = $"namespace {spacename}{Environment.NewLine}";

            return format;
        }

        public override string WriteProperty(BaseObj prop)
        {
            string format = $"public {{0}} {{1}} {{get; set; }}";
            string propname = prop.Name;
            string proptype = prop.ObjType.ToString();
            return string.Format(format, proptype, propname);
        }

    }
}
