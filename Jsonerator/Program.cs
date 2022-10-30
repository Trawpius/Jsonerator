using System;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Jsonerator.JsonObj;

namespace Jsonerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath;
            string spacename;
            //program execution starts from here
            if(args.Length != 2)
            {
                Console.WriteLine("Incorrect arguments.");
                Console.WriteLine("jsonerator [filepath] [namespace]");
                //Console.ReadKey();
                // return;

                spacename = "TestJsonerator";
                filepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "jsontest.json");
            }
            else
            {
                filepath = args[0];
                spacename = args[1];
            }
                    

            if (!File.Exists(filepath))
            {
                Console.WriteLine($"{filepath} does not exist");
                Console.ReadKey();
            }



            string txt = File.ReadAllText(filepath);
            JObject obj = JsonDeserializer.StringToJObject(txt);
            ObjectObj jsonObj = Objenerator.Objenerate(obj);

            ClassAuthor.ClassAuthor author = new ClassAuthor.ClassAuthor(jsonObj, "genericoutput");
            author.WriteCSharpDebug();
            Console.ReadKey();
        } 
    }
}