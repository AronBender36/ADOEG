using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOEG {
    class Program {
        static void main(string[] args) {
            //InsertData();
            //UpdateData();
            //DeleteData();
            //SelectData();
            DisconSelect();
        }

        public static SqlConnection con;
        public static SqlCommand cmd;

        private static void SelectData() {
            SqlConnection con = getCon();
            cmd = new SqlCommand("select * from employee");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) { //loop number of records
                for (int i = 0; i < dr.FieldCount; i++) { //loop number of columnss
                    Console.WriteLine(dr[i]);
                }
            }
        }

        private static SqlConnection getCon() {
            con = new SqlConnection("Data Source=CIWE-MTP-SQL1;Initial Catalog=ARON;Integrated Security=true");
            con.Open();
            return con;
        }

        private static void InsertData() {
            con = getCon();
            Console.WriteLine("Enter Empid,Empname,Salary,Doj,Type,Deptid,Mgr for Record Insertion");
            int eid = Convert.ToInt32(Console.ReadLine());
            string empname = Console.ReadLine();
            float sal = float.Parse(Console.ReadLine());
            DateTime doj = Convert.ToDateTime(Console.ReadLine());
            bool etype = Convert.ToBoolean(Console.ReadLine());
            int did = Convert.ToInt32(Console.ReadLine());
            int mgr = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("insert into employee values(@eid,@ename,@sal,@doj,@etype,@did,@mgr)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@ename", empname);
            cmd.Parameters.AddWithValue("@sal", sal);
            cmd.Parameters.AddWithValue("@doj", doj);
            cmd.Parameters.AddWithValue("@etype", etype);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@mgr", mgr);
            cmd.ExecuteNonQuery();
        }

        private static void UpdateData() {
            con = getCon();
            Console.WriteLine("Enter Empid,Salary,Deptid for Record Update by Empid");
            int eid = Convert.ToInt32(Console.ReadLine());
            string empname = Console.ReadLine();
            float sal = float.Parse(Console.ReadLine());
            DateTime doj = Convert.ToDateTime(Console.ReadLine());
            bool etype = Convert.ToBoolean(Console.ReadLine());
            int did = Convert.ToInt32(Console.ReadLine());
            int mgr = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("update employee setsalary=@sal,deptid=@did,manager=@mgr where Empid=@eid");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@sal", sal);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.ExecuteNonQuery();
        }

        private static void DeleteData() {
            con = getCon();
            Console.WriteLine("Enter Empid");
            int eid = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete from employee where Empid=@eid");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.ExecuteNonQuery();
        }

        private static void DisconSelect() {
            con = getCon();
            cmd = new SqlCommand("select * from employee");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in  dt.Rows) {
                foreach(var item in dr.ItemArray) {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
