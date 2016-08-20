using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string nomeElemento = "";
            double valorBruto = 0.0;

            XmlTextReader reader = new XmlTextReader("santour.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        nomeElemento = reader.Name;
                        Console.Write("<" + nomeElemento);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        if (nomeElemento == "valorBruto")
                        {
                            ++i;
                            valorBruto = Convert.ToDouble(reader.Value);
                        }
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
