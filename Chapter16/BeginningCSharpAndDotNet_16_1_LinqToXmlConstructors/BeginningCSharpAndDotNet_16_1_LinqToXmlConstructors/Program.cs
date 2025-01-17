﻿using System;
using System.Xml.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNet_16_1_LinqToXmlConstructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = new XDocument(
                new XElement("customers",
                    new XElement("customer",
                        new XAttribute("ID", "A"),
                        new XAttribute("City", "New York"),
                        new XAttribute("Region", "NorthAmerica"),
                        new XElement("order",
                            new XAttribute("Item", "Widget"),
                            new XAttribute("Price", 100)
                        ),
                        new XElement("order",
                            new XAttribute("Item", "Tire"),
                            new XAttribute("Price", 200)
                        )
                    ),
                    new XElement("customer",
                        new XAttribute("ID", "B"),
                        new XAttribute("City", "Mumbai"),
                        new XAttribute("Region", "Asia"),
                        new XElement("order",
                            new XAttribute("Item", "Oven"),
                            new XAttribute("Price", 501)
                        )
                    )
                )
            );
            WriteLine(xdoc);
            Write("Program finished, press Enter/Return to continue:");
            ReadKey();
        }
    }
}
