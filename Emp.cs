using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEG {
    class Emp {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public float Sal { get; set; }
        public string City { get; set; }

        public Emp() {

        }

        public Emp(int eid, string name, float sal, string city) {
            Eid = eid;
            Ename = name;
            Sal = sal;
            City = city;
        }

        public static List<Emp> employees = new List<Emp>();

        public List<Emp> getAllEmps() {
            employees.Add(new Emp(1, "Rick", 23000, "LA"));
            employees.Add(new Emp(2, "Maria", 63000, "SF"));
            employees.Add(new Emp(3, "Tom", 83000, "PY"));
            return employees;
        }

        public override string ToString() {
            return String.Format(Eid + ": " + Ename + " " + Sal + " belongs to  " + City);
        }

        public static bool operator ==(Emp a, Emp b) {
            return a.Eid == b.Eid;
        }

        public static bool operator !=(Emp a, Emp b) {
            return a.Eid != b.Eid;
        }


    }
}
