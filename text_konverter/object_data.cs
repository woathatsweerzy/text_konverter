using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace text_konverter
{
    public class object_data
    {
        public string name;
        public string lenght;
        public string width;

        public static List<object_data> into_txt(string path_to_file)
        {
            List<object_data> props = reading_lines.lines_reader(path_to_file);
            foreach (object_data i in props)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.lenght);
                Console.WriteLine(i.width);

            }
            return props; 
        }
        public static void out_txt(string new_path, List<object_data> props)
        {
            File.WriteAllText(new_path, "");
            foreach (object_data i in props)
            {
                File.AppendAllText(new_path, i.name + "\n");
                File.AppendAllText(new_path, i.lenght + "\n");
                File.AppendAllText(new_path, i.width + "\n");
            }
            
        }
        public static List<object_data> into_json(string path_to_file)
        {
            string Json_text = File.ReadAllText(path_to_file);
            List<object_data> props = JsonConvert.DeserializeObject<List<object_data>>(Json_text);
            foreach (object_data i in props)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.lenght);
                Console.WriteLine(i.width);
            }
            return props;
        }
        public static void out_json(string new_path, string text)
        {
            
            string Json_text = text;
            string Join = string.Join("", Json_text);
            File.WriteAllText(new_path, Join);
        }
        public static List<object_data> into_xml(string path_to_file)
        {
            List<object_data> props;
            XmlSerializer xml = new XmlSerializer(typeof(List<object_data>));
            using (FileStream fs = new FileStream(path_to_file, FileMode.Open))
            {
                props = (List<object_data>) xml.Deserialize(fs);
            }
            foreach (object_data i in props)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.lenght);
                Console.WriteLine(i.width);
            }
            return props;
        }
        public static void out_xml(string path_to_file, string new_path, List<object_data> props)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<object_data>));
            using (FileStream fs = new FileStream(new_path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, props);
            }
        }
    } 
}
