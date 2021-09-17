using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEG {
    class CollLINQeg {
        public static void main() {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = (from i in numbers
                           where i % 2 == 0
                           select i).ToList();

            Console.WriteLine("Even Numbers using Query Syntax");
            foreach (var item in result) {
                Console.WriteLine(item);
            }

            Console.WriteLine("Even Numbers using Method Syntax");
            var res = numbers.Where(x => x % 2 == 0).Select(x => x).OrderBy(x=>x);
            foreach (var item in res) {
                Console.WriteLine(item);
            }


            List<string> names = new List<string>();
            names.Add("Tom");
            names.Add("Teddy");
            names.Add("Rick");
            names.Add("Maria");
            names.Add("Mona");

            var result2 = (from name in names
                      where name.StartsWith("M")
                      select name).ToList();
            foreach(var item in result2) {
                Console.WriteLine(item);
            }

            var res2 = result2.Where(name => name.StartsWith('M')).Select(name => name).OrderBy(name => name);
            foreach (var item in res2) {
                Console.WriteLine(item);
            }

        }
    }
}
