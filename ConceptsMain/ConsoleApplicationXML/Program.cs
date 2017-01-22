using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace ConsoleApplicationXML
{
    class Program
    {
        static void Main(string[] args)
        {

            string myXML = @"<Departments>
                       <Department>Account</Department>
                       <Department>Sales</Department>
                       <Department>Pre-Sales</Department>
                       <Department>Marketing</Department>
                       </Departments>";

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            var allDecendantsOfDepartments = xdoc.Element("Departments").Descendants();

            foreach (XElement dept in allDecendantsOfDepartments)
            {
                Console.WriteLine("Department Name is {0}", dept.Value);

            }



            Console.ReadLine();

        }
    }
}
