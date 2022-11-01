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
            string filepath = null;
            string outputpath = Assembly.GetExecutingAssembly().Location;
            string spacename = "Default.Space.Name";
            string classname = "DefaultClass";

            // Argument handling
            if (args.Length >= 1)
                filepath = args[0];
            if(args.Length >= 2)
                outputpath = args[1];
            if (args.Length >= 3)
                spacename = args[3];
            if (args.Length >= 4)
                classname = args[4];
            if (args.Length >= 5 || args.Length < 1)
            {
                Console.WriteLine("Incorrect arguments.");
                Console.WriteLine("jsonerator [filepath] [outputdirectory] [namespace] [classname]");
                Console.WriteLine("Type any button to exit...");
                Console.ReadKey();
                return;
            }

            if (!File.Exists(filepath))
            {
                Console.WriteLine($"{filepath} does not exist");
                Console.WriteLine("Type any button to exit...");
                Console.ReadKey();
            }

            if(Directory.Exists(outputpath))
            {
                Console.WriteLine($"{outputpath} does not exist");
                Console.WriteLine("Type any button to exit...");
                Console.ReadKey();
            }



            string txt = File.ReadAllText(filepath);
            JObject obj = JsonDeserializer.StringToJObject(txt);
            ObjectObj jsonObj = Objenerator.Objenerate(obj);

            ClassAuthor.ClassAuthor author = new ClassAuthor.ClassAuthor(jsonObj, outputpath, spacename);


            Console.WriteLine("Choose your output language:");
            bool valid = false;
            Language language = Language.Null;

            while (!valid)
            {
                string input = Console.ReadLine().ToLower();
                if (input.Equals("c#") || input.Equals("csharp"))
                    language = Language.CSharp;
                // Only C# valid LOL but in theory...
                else
                    language = Language.Null;

                if (language != Language.Null)
                    valid = true;
                else
                {
                    Console.WriteLine("Incorrect input. Choose your output language. Ex. Csharp");
                    valid = false;
                }
            }

            author.Write(language);
            Console.ReadKey();
        } 
    }
}