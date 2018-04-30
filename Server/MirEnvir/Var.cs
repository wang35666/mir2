using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Var
    {
        private static List<Var> list = new List<Var>();

        public string value;

        public int intValue;

        public bool boolValue;

        public string fieldName;

        public Var(string fieldName, string value)
        {
            this.fieldName = fieldName;
            this.value = value;
            parse();
        }

        private void parse()
        {
            int.TryParse(value, out intValue);
            bool.TryParse(value, out boolValue);
        }

        public static Var FindVar(string field, string defaultVal)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].fieldName == field)
                    return list[i];
            }

            Var var = new Var(field, defaultVal);
            list.Add(var);

            return var;
        }

        public static void Load(InIReader reader)
        {
            List<string> list = reader.getContents();
            for (int a = 0; a < list.Count; a++)
            {
                if (String.CompareOrdinal(list[a], "[Var]") == 0)
                    for (int b = a + 1; b < list.Count; b++)
                    {
                        string[] arr = list[b].Split('=');
                        FindVar(arr[0], arr[1]);
                    }
            }
        }

        public static void Save(InIReader reader)
        {
            for (int i = 0; i < list.Count; i++)
                reader.Write("Var", list[i].fieldName, list[i].value);
        }
    }
}
