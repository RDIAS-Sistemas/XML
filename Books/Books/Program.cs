using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Books
{
    class Program
    {
        public static double StringToOtherTypes(string stringVal)
        {
            if (stringVal.Contains("."))
                stringVal = stringVal.Replace(".", ",");

            decimal decval = System.Convert.ToDecimal(stringVal);
            double doubleval = System.Convert.ToDouble(stringVal);
            float fval = System.Convert.ToSingle(stringVal);

            return doubleval;
        }

        static void Main(string[] args)
        {
            int qtd = 0;
            string nomeElemento = "";
            double valorBruto = 0.0;

            XmlTextReader reader = new XmlTextReader("santour.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        nomeElemento = reader.Name;
                        //Console.Write("<" + nomeElemento);
                    
                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        //Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        if (nomeElemento == "valorBruto")
                        {
                            ++qtd;
                            valorBruto = valorBruto + StringToOtherTypes(reader.Value);
                        }
                        //Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");
                        break;
                }
            }

            Console.WriteLine("A quantidade de transações foi de " + qtd);
            Console.WriteLine("O valor total das transações é de R$ " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorBruto));
            Console.ReadLine();
        }
    }
}
