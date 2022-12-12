using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo
{
    public class OrderOfInitialization
    {
        public OrderOfInitialization()
        {
            Console.WriteLine("Constructor");
        }
        static OrderOfInitialization()
        {
            Console.WriteLine("Static constructor");
        }

        public static int s1 = GetValue("Static field 1");
        public int ns1 = GetValue("Non-static field 1");
        public static int s2 = GetValue("Static field 2");
        public int ns2 = GetValue("Non-static field 2");

        private static int GetValue(string message)
        {
            Console.WriteLine(message);
            return 1;
        }

        public void NonstaticFoo()
        {
            Console.WriteLine("Non-static method");
        }

        public static void StaticFoo()
        {
            Console.WriteLine("Static method");
        }
    }

}
