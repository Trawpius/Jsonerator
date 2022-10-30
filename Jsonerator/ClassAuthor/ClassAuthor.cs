using Jsonerator.JsonObj;
using Jsonerator.ClassWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator.ClassAuthor
{
    public class ClassAuthor
    {

        public ClassAuthor(ObjectObj obj, string outfile, string spacename = "Default.Namespace")
        { 
            Obj = obj;
            Outfile = outfile;
            Spacename = spacename;
        }

        private ObjectObj Obj { get; set; }
        private string Outfile { get; set; }
        private string Spacename { get; set; }

        private ClassWriter.ClassWriter ClassWriter { get; set; }

        public void WriteCSharp()
        {
            ClassWriter = new CSharpClassWriter();
            using (StreamWriter fout = new StreamWriter(Outfile))
            {
                fout.WriteLine(ClassWriter.WriteInclude());

                string clss = ClassWriter.WriteClass(Obj);
                string nmspace = ClassWriter.WriteNamespace(Spacename);

                fout.WriteLine(string.Format(nmspace, clss));
            }
        }

        public void WriteCSharpDebug()
        {
            ClassWriter = new CSharpClassWriter();

            Console.WriteLine(ClassWriter.WriteInclude());

            string clss = ClassWriter.WriteClass(Obj);
            string nmspace = ClassWriter.WriteNamespace(Spacename);

            Console.WriteLine(nmspace);
            Console.WriteLine(ClassWriter.WriteBracket(true));
            Console.WriteLine(clss);
            Console.WriteLine(ClassWriter.WriteBracket(false));

        }
    }
}
