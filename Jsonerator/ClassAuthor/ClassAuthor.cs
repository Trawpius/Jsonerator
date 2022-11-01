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

        public ClassAuthor(ObjectObj obj, string outpath, string spacename = "Default.Namespace")
        {
            Obj = obj;
            Outpath = outpath;
            Spacename = spacename;
        }

        private ObjectObj Obj { get; set; }
        private string Outfile { get; set; }
        private string Outpath { get; set; }
        private string Spacename { get; set; }

        private ClassWriter.ClassWriter ClassWriter { get; set; }

        public void WriteCSharp()
        {
            ClassWriter = new CSharpClassWriter();
            Outfile = Path.Combine(Outpath, Obj.Name + ".cs");

#if DEBUG
            using (StreamWriter fout = new StreamWriter(Console.OpenStandardOutput()))
#else
            using (StreamWriter fout = new StreamWriter(Outfile))
#endif
            {
                string nmspace = ClassWriter.WriteNamespace(Spacename);
                string clss = ClassWriter.WriteClass(Obj);
                List<BaseObj> allobjs = Obj.Traverse();
                List<string> classes = new List<string>();

                foreach (BaseObj a in allobjs)
                    classes.Add(ClassWriter.WriteClass((ObjectObj)a));


                fout.WriteLine(ClassWriter.WriteInclude());
                fout.WriteLine(nmspace);
                fout.WriteLine(ClassWriter.WriteBracket(true));
                fout.WriteLine(clss);
                foreach (string c in classes)
                    fout.WriteLine(c);
                fout.WriteLine(ClassWriter.WriteBracket(false));
            }
        }

        internal void Write(Language language)
        {
            switch(language)
            {
                case Language.CSharp:
                    WriteCSharp();
                    break;
                default:
                    // none implemented :)
                    throw new NotImplementedException();
            }
        }
    }
}
