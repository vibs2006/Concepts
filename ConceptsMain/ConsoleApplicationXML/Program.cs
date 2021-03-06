﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace ConsoleApplicationXML
{
    class Program
    {
        static string myXML = @"<Departments>
                       <Department>Account</Department>
                       <Department>Sales</Department>
                       <Department>Pre-Sales</Department>
                       <Department>Marketing</Department>
                       </Departments>";

        static void Main(string[] args)
        {
            //ReadAndDisplayStringXML();
            //AddNewElementandValuesToExisitingInlineXMLstring();
            DeleteElementFromXML();
            Console.ReadLine();
        }

        /// <summary>
        /// Read and Display XML String
        /// </summary>
        static void ReadAndDisplayStringXML()
        {
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            var allDecendantsOfDepartments = xdoc.Element("Departments").Descendants();

            foreach (XElement dept in allDecendantsOfDepartments)
            {
                Console.WriteLine("Department Name is {0}", dept.Value);
            }
        }

        static void AddNewElementandValuesToExisitingInlineXMLstring()
        {
            XDocument xdoc = XDocument.Parse(myXML);

            xdoc.Element("Departments").Add(new XElement("Department", "Finance"));
            xdoc.Element("Departments").Add(new XElement("Department", "Support"));

            var getAllDecendants = xdoc.Element("Departments").Descendants();

            Console.WriteLine("List of New Department is:");
            foreach (var element in getAllDecendants)
            {
                Console.WriteLine("\r" + element.Value);
            }

            xdoc.Save("Output.xml");
        }

        static void DeleteElementFromXML()
        {
            XDocument xdoc = XDocument.Parse(myXML);

            xdoc.Element("Departments").Descendants().Where(x => x.Value == "Marketing").Remove();

            var newDecendants = xdoc.Element("Departments").Descendants();
            Console.WriteLine("Updated List is ");
            foreach(var elem in newDecendants)
            {
                Console.WriteLine(elem.Value);
            }


        }

    }
}
