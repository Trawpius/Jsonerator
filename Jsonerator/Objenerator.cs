using Jsonerator.JsonObj;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator
{
    public static class Objenerator
    {
        public static ObjectObj Objenerate(JObject jsonObject)
        {
            return BuildObject(jsonObject);
        }


        private static ObjectObj BuildObject(JObject parent)
        {
            string name = parent.Path.Split('.').Last();
            ObjectObj obj = new ObjectObj(name);

            List<BaseObj> children = new List<BaseObj>();

            foreach(var child in parent.Children())
            {
                switch(child.Type)
                {
                    case JTokenType.Object:
                        ObjectObj childobj = BuildObject((JObject)child);
                        children.Add(childobj);
                        break;
                    case JTokenType.Array:
                        ArrayObj childarry = BuildArray((JArray)child);
                        children.Add(childarry);
                        break;
                    case JTokenType.Property:
                        BaseObj childprop = BuildChild((JProperty)child);
                        children.Add(childprop);
                        break;
                    default:
                        break;    
                }
            }

            obj.Children = children;
            return obj;
        }

        private static BaseObj BuildChild(JProperty property)
        {
            JTokenType type = property.First().Type;

            switch (type)
            {
                case JTokenType.Array:
                    return BuildArray((JArray)property.First());
                case JTokenType.Object:
                    return BuildObject((JObject)property.First());
                case JTokenType.Property:
                    return BuildProperty((JValue)property.First());
                default:
                    return BuildProperty((JValue)property.First());
            }
        }

        private static BaseObj BuildProperty(JValue property)
        {
            JTokenType type = property.Type;
            string name = property.Path.Split('.').Last();

            switch (type)
            {
                case JTokenType.Boolean:
                    return new PropertyObj(name, ObjType.Boolean);
                case JTokenType.Integer:
                    return new PropertyObj(name, ObjType.Integer);
                case JTokenType.Float:
                    return new PropertyObj(name, ObjType.Float);
                case JTokenType.String:
                    return new PropertyObj(name, ObjType.String);
                case JTokenType.TimeSpan:
                    return new PropertyObj(name, ObjType.TimeSpan);
                default:
                    return new PropertyObj(name, ObjType.Null);
            }
        }

        private static ArrayObj BuildArray(JArray array)
        {
            string name = array.Path.Split('.').Last();
            JTokenType type = array.First().Type;
            
            switch(type)
            {
                case JTokenType.Property:
                    BaseObj prop = BuildChild((JProperty)array.First());
                    return new ArrayObj(name, prop);
                case JTokenType.Array:
                    ArrayObj childarray = BuildArray((JArray)array.First());
                    return new ArrayObj(name, childarray);
                    case JTokenType.Object:
                    ObjectObj obj = BuildObject((JObject)array.First());
                    return new ArrayObj(name, obj);
                default:
                    BaseObj childprop = BuildProperty((JValue)array.First());
                    return new ArrayObj(name, childprop);

            }
        }
    }
}
