using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_konverter
{
    internal class reading_lines
    {
        public static List<object_data> lines_reader(string path_to_file)
        {
            string[] lines = File.ReadAllLines(path_to_file);
            object_data rectangle = new object_data();
            rectangle.name = lines[0];
            rectangle.width = lines[1];
            rectangle.lenght = lines[2];
            object_data square = new object_data();
            square.name = lines[3];
            square.width = lines[4];
            square.lenght = lines[5];
            object_data rectangle1 = new object_data();
            rectangle1.name = lines[6];
            rectangle1.width = lines[7];
            rectangle1.lenght = lines[8];
            List<object_data> props = new List<object_data>();
            props.Add(rectangle);
            props.Add(square);
            props.Add(rectangle1);
            return (props);
        }
        
    }
}
