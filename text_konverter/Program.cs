using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using text_konverter;
using static System.Net.Mime.MediaTypeNames;

namespace text_konverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<object_data> props = new List<object_data>();

                string path_to_file = (request_path());
                string text = lookup_text(path_to_file, props);
                Console.Clear();



            }
            static string request_path()
            {
                Console.WriteLine("Введите путь до нужного файла:");
                Console.WriteLine("(Пример: C:\\Users\\1\\Desktop\\ИмяФайла.txt )");
                Console.WriteLine("--------------------------------------------------");
                string path_to_file = Console.ReadLine();
                Console.Clear();
                return (path_to_file);
            }
            static string lookup_text(string path_to_file, List<object_data> props)
            {
                ConsoleKeyInfo key;
                string text = File.ReadAllText(path_to_file);
                while (true)
                {
                    Console.WriteLine("Сохранение файла в одном из форматов (txt, json, xml) - F1");
                    Console.WriteLine("Выход - Escape");
                    Console.WriteLine("--------------------------------------------------");
                    if (path_to_file.Contains(".txt"))
                    {
                        props = object_data.into_txt(path_to_file);
                    }

                    if (path_to_file.Contains(".json"))
                    {
                        props = object_data.into_json(path_to_file);
                    }

                    if (path_to_file.Contains(".xml"))
                    {
                        props = object_data.into_xml(path_to_file);
                    }
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.F1)
                    {
                        text = File.ReadAllText(path_to_file);
                        save_file(path_to_file, props);
                        break;
                    }
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    Console.Clear();
                }
                return text;
            }
            static void save_file(string path_to_file, List<object_data> props )
             {
                Console.Clear();
                Console.WriteLine("Введите путь до файла:");
                Console.WriteLine("(Пример: C:\\Users\\1\\Desktop\\ИмяФайла.txt )");
                Console.WriteLine("--------------------------------------------------");
                string new_path = Console.ReadLine();

                if (new_path.Contains(".txt"))
                {
                    object_data.out_txt(new_path, props);
                }
                if (new_path.Contains(".json"))
                {
                    object_data.out_json(new_path, JsonConvert.SerializeObject(props));
                }
                if (new_path.Contains(".xml"))
                {
                    object_data.out_xml(path_to_file, new_path, props);     
                }
            }
        }
    }
}