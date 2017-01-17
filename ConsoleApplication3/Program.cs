using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawInput {

    class Program {

        static void Main(string[] args) {
            Test.test1();
            Console.ReadKey();

        }

        static String binS(byte b) {
            return Convert.ToString(b, 2);
        }
    }
}
