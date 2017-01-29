using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationVirtualOverride
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyBaseClass
    {
        // virtual auto-implemented property. Overrides can only
        // provide specialized behavior if they implement get and set accessors.
        public string Name { get; set; }

        // ordinary virtual property with backing field
        private int num;
        public int Number
        {
            get { return num; }
            set { num = value; }
        }
    }


    class MyDerivedClass : MyBaseClass
    {
        private string name;

        // Override auto-implemented property with ordinary property
        // to provide specialized accessor behavior.
        public new string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != String.Empty)
                {
                    name = value;
                }
                else
                {
                    name = "Unknown";
                }
            }
        }

    }
}
