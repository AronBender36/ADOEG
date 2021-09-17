using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEG {
    class EmpClient {
        public static void Main() {
            Emp e = new Emp();
            List<Emp> employees = e.getAllEmps();
            var res = (from i in employees
                       where i.Sal > 30000 && i.City == "SF"
                       select i).ToList();
            foreach(var item in res) {
                Console.WriteLine(item);
            }
            var res1 = employees.Where(x => x.Sal > 30000 && x.City == "SF").Select(x => x);
            foreach (var item in res1) {
                Console.WriteLine(item);
            }
        }
    }
}
